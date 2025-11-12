using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CofrinhoSenhas.WebAPI.Controladores
{
    /// <summary>
    /// Controller para gerenciar usuários do sistema
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenServico _tokenServico;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuarioServico usuarioServico, ITokenServico tokenServico, IConfiguration configuration)
        {
            _usuarioServico = usuarioServico;
            _tokenServico = tokenServico;
            _configuration = configuration;
        }

        /// <summary>
        /// Busca todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObterUsuarios()
        {
            var usuarios = await _usuarioServico.ObterTodosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Busca um usuário específico pelo ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Dados do usuário</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> ObterUsuario(int id)
        {
            var usuario = await _usuarioServico.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Dados do usuário</returns>
        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> ObterUsuarioPorEmail(string email)
        {
            var usuario = await _usuarioServico.ObterPorEmailAsync(email);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Cria um novo usuário no sistema
        /// </summary>
        /// <param name="criarUsuarioDto">Dados do novo usuário</param>
        /// <returns>Dados do usuário criado</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioDTO>> CriarUsuario(CriarUsuarioDTO criarUsuarioDto)
        {
            try
            {
                var usuario = await _usuarioServico.CriarAsync(criarUsuarioDto);
                return CreatedAtAction(nameof(ObterUsuario), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="atualizarUsuarioDto">Novos dados do usuário</param>
        /// <returns>Dados do usuário atualizado</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> AtualizarUsuario(int id, AtualizarUsuarioDTO atualizarUsuarioDto)
        {
            try
            {
                var usuario = await _usuarioServico.AtualizarAsync(id, atualizarUsuarioDto);
                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um usuário do sistema
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            try
            {
                await _usuarioServico.RemoverAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Faz login no sistema e retorna um token JWT
        /// </summary>
        /// <param name="loginDto">Email e senha do usuário</param>
        /// <returns>Dados do usuário, token JWT e data de expiração</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginRespostaDTO>> FazerLogin(LoginDTO loginDto)
        {
            var usuario = await _usuarioServico.AutenticarAsync(loginDto);
            if (usuario == null)
                return Unauthorized("Email ou senha inválidos");

            var token = _tokenServico.GerarToken(usuario);
            var expiracaoHoras = int.Parse(_configuration["JwtSettings:ExpiracaoHoras"] ?? "8");

            var resposta = new LoginRespostaDTO
            {
                Usuario = usuario,
                Token = token,
                DataExpiracao = DateTime.UtcNow.AddHours(expiracaoHoras)
            };

            return Ok(resposta);
        }

        /// <summary>
        /// Altera a senha de um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="alterarSenhaDto">Senha atual e nova senha</param>
        /// <returns>Mensagem de sucesso</returns>
        [HttpPost("{id}/alterar-senha")]
        [Authorize]
        public async Task<IActionResult> AlterarSenha(int id, [FromBody] AlterarSenhaDTO alterarSenhaDto)
        {
            var sucesso = await _usuarioServico.AlterarSenhaAsync(id, alterarSenhaDto.SenhaAtual, alterarSenhaDto.NovaSenha);
            if (!sucesso)
                return BadRequest("Senha atual incorreta ou usuário não encontrado");

            return Ok("Senha alterada com sucesso");
        }
    }
}

