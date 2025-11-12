using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CofrinhoSenhas.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço responsável por gerar tokens JWT para autenticação
    /// </summary>
    public class TokenServico : ITokenServico
    {
        private readonly IConfiguration _configuration;

        public TokenServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gera um token JWT com as informações do usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário para incluir no token</param>
        /// <returns>Token JWT em formato string</returns>
        public string GerarToken(UsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(_configuration["JwtSettings:ChaveSecreta"] ?? throw new InvalidOperationException("JWT ChaveSecreta não configurada"));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(
                    int.Parse(_configuration["JwtSettings:ExpiracaoHoras"] ?? "8")
                ),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave), 
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _configuration["JwtSettings:Emissor"],
                Audience = _configuration["JwtSettings:Audiencia"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
