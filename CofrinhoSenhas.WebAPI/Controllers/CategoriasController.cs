using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CofrinhoSenhas.WebAPI.Controladores
{
    /// <summary>
    /// Controller para gerenciar categorias de senhas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriasController(ICategoriaServico categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        /// <summary>
        /// Busca todas as categorias cadastradas
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> ObterCategorias()
        {
            var categorias = await _categoriaServico.ObterTodosAsync();
            return Ok(categorias);
        }

        /// <summary>
        /// Busca todas as categorias de um usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de categorias do usuário</returns>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> ObterCategoriasPorUsuario(int idUsuario)
        {
            var categorias = await _categoriaServico.ObterCategoriasPorUsuarioAsync(idUsuario);
            return Ok(categorias);
        }

        /// <summary>
        /// Busca uma categoria específica pelo ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Dados da categoria</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> ObterCategoria(int id)
        {
            var categoria = await _categoriaServico.ObterPorIdAsync(id);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="criarCategoriaDto">Dados da nova categoria</param>
        /// <returns>Dados da categoria criada</returns>
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> CriarCategoria(CriarCategoriaDTO criarCategoriaDto)
        {
            try
            {
                var categoria = await _categoriaServico.CriarAsync(criarCategoriaDto);
                return CreatedAtAction(nameof(ObterCategoria), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <param name="atualizarCategoriaDto">Novos dados da categoria</param>
        /// <returns>Dados da categoria atualizada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaDTO>> AtualizarCategoria(int id, AtualizarCategoriaDTO atualizarCategoriaDto)
        {
            try
            {
                var categoria = await _categoriaServico.AtualizarAsync(id, atualizarCategoriaDto);
                return Ok(categoria);
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
        /// Remove uma categoria
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirCategoria(int id)
        {
            try
            {
                await _categoriaServico.RemoverAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

