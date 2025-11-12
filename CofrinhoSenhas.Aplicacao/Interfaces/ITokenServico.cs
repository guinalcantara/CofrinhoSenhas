using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para geração de tokens JWT de autenticação
    /// </summary>
    public interface ITokenServico
    {
        /// <summary>
        /// Gera um token JWT para o usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        /// <returns>Token JWT em formato string</returns>
        string GerarToken(UsuarioDTO usuario);
    }
}
