using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CofrinhoSenhas.WebAPI.Controladores
{
    /// <summary>
    /// Controller para gerenciar etiquetas de senhas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EtiquetasController : ControllerBase
    {
        private readonly IEtiquetaServico _etiquetaServico;

        public EtiquetasController(IEtiquetaServico etiquetaServico)
        {
            _etiquetaServico = etiquetaServico;
        }

        /// <summary>
        /// Busca todas as etiquetas cadastradas
        /// </summary>
        /// <returns>Lista de etiquetas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtiquetaDTO>>> ObterEtiquetas()
        {
            IEnumerable<EtiquetaDTO> etiquetas = await _etiquetaServico.ObterTodosAsync();
            return Ok(etiquetas);
        }

        /// <summary>
        /// Busca todas as etiquetas de um usuáro
        /// </summary>
        /// <param name="idUsuario">ID do usuáro</param>
        /// <returns>Lista de etiquetas do usuáro</returns>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<EtiquetaDTO>>> ObterEtiquetasPorUsuario(int idUsuario)
        {
            IEnumerable<EtiquetaDTO> etiquetas = await _etiquetaServico.ObterEtiquetasPorUsuarioAsync(idUsuario);
            return Ok(etiquetas);
        }

        /// <summary>
        /// Busca uma etiqueta espec?fica pelo ID
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <returns>Dados da etiqueta</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EtiquetaDTO>> ObterEtiqueta(int id)
        {
            EtiquetaDTO? etiqueta = await _etiquetaServico.ObterPorIdAsync(id);
            if (etiqueta == null)
                return NotFound();

            return Ok(etiqueta);
        }

        /// <summary>
        /// Cria uma nova etiqueta
        /// </summary>
        /// <param name="criarEtiquetaDto">Dados da nova etiqueta</param>
        /// <returns>Dados da etiqueta criada</returns>
        [HttpPost]
        public async Task<ActionResult<EtiquetaDTO>> CriarEtiqueta(CriarEtiquetaDTO criarEtiquetaDto)
        {
            try
            {
                EtiquetaDTO etiqueta = await _etiquetaServico.CriarAsync(criarEtiquetaDto);
                return CreatedAtAction(nameof(ObterEtiqueta), new { id = etiqueta.Id }, etiqueta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma etiqueta existente
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <param name="atualizarEtiquetaDto">Novos dados da etiqueta</param>
        /// <returns>Dados da etiqueta atualizada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<EtiquetaDTO>> AtualizarEtiqueta(int id, AtualizarEtiquetaDTO atualizarEtiquetaDto)
        {
            try
            {
                EtiquetaDTO etiqueta = await _etiquetaServico.AtualizarAsync(id, atualizarEtiquetaDto);
                return Ok(etiqueta);
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
        /// Remove uma etiqueta
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirEtiqueta(int id)
        {
            try
            {
                await _etiquetaServico.RemoverAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

