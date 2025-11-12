using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CofrinhoSenhas.WebAPI.Controladores
{
    /// <summary>
    /// Controller para gerenciar senhas armazenadas no cofre
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SenhasController : ControllerBase
    {
        private readonly ISenhaServico _senhaServico;

        public SenhasController(ISenhaServico senhaServico)
        {
            _senhaServico = senhaServico;
        }

        /// <summary>
        /// Busca todas as senhas cadastradas
        /// </summary>
        /// <returns>Lista de senhas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SenhaDTO>>> ObterSenhas()
        {
            var senhas = await _senhaServico.ObterTodosAsync();
            return Ok(senhas);
        }

        /// <summary>
        /// Busca todas as senhas de um usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de senhas do usuário</returns>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<SenhaDTO>>> ObterSenhasPorUsuario(int idUsuario)
        {
            var senhas = await _senhaServico.ObterSenhasPorUsuarioAsync(idUsuario);
            return Ok(senhas);
        }

        /// <summary>
        /// Busca todas as senhas de uma categoria
        /// </summary>
        /// <param name="idCategoria">ID da categoria</param>
        /// <returns>Lista de senhas da categoria</returns>
        [HttpGet("categoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable<SenhaDTO>>> ObterSenhasPorCategoria(int idCategoria)
        {
            var senhas = await _senhaServico.ObterSenhasPorCategoriaAsync(idCategoria);
            return Ok(senhas);
        }

        /// <summary>
        /// Busca uma senha específica pelo ID
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <returns>Dados da senha (criptografada)</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SenhaDTO>> ObterSenha(int id)
        {
            var senha = await _senhaServico.ObterPorIdAsync(id);
            if (senha == null)
                return NotFound();

            return Ok(senha);
        }

        /// <summary>
        /// Busca uma senha com o valor descriptografado
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <returns>Dados da senha com valor em texto</returns>
        [HttpGet("{id}/descriptografada")]
        public async Task<ActionResult<SenhaDescriptografadaDTO>> ObterSenhaDescriptografada(int id)
        {
            var senha = await _senhaServico.ObterDescriptografadaPorIdAsync(id);
            if (senha == null)
                return NotFound();

            return Ok(senha);
        }

        /// <summary>
        /// Cria uma nova senha no cofre
        /// </summary>
        /// <param name="criarSenhaDto">Dados da nova senha</param>
        /// <returns>Dados da senha criada</returns>
        [HttpPost]
        public async Task<ActionResult<SenhaDTO>> CriarSenha(CriarSenhaDTO criarSenhaDto)
        {
            try
            {
                var senha = await _senhaServico.CriarAsync(criarSenhaDto);
                return CreatedAtAction(nameof(ObterSenha), new { id = senha.Id }, senha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma senha existente
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <param name="atualizarSenhaDto">Novos dados da senha</param>
        /// <returns>Dados da senha atualizada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<SenhaDTO>> AtualizarSenha(int id, AtualizarSenhaDTO atualizarSenhaDto)
        {
            try
            {
                var senha = await _senhaServico.AtualizarAsync(id, atualizarSenhaDto);
                return Ok(senha);
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
        /// Remove uma senha do cofre
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirSenha(int id)
        {
            try
            {
                await _senhaServico.RemoverAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

