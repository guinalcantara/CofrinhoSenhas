using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CofrinhoSenhas.WebAPI.Controladores
{
    /// <summary>
    /// Controller para gerenciar logs de eventos do sistema
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LogEventosController : ControllerBase
    {
        private readonly ILogEventoServico _logEventoServico;

        public LogEventosController(ILogEventoServico logEventoServico)
        {
            _logEventoServico = logEventoServico;
        }

        /// <summary>
        /// Busca todos os logs de eventos cadastrados
        /// </summary>
        /// <returns>Lista de logs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEventoDTO>>> ObterLogEventos()
        {
            var logEventos = await _logEventoServico.ObterTodosAsync();
            return Ok(logEventos);
        }

        /// <summary>
        /// Busca todos os logs de eventos de um usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de logs do usuário</returns>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<LogEventoDTO>>> ObterLogEventosPorUsuario(int idUsuario)
        {
            var logEventos = await _logEventoServico.ObterLogEventosPorUsuarioAsync(idUsuario);
            return Ok(logEventos);
        }

        /// <summary>
        /// Busca um log de evento específico pelo ID
        /// </summary>
        /// <param name="id">ID do log</param>
        /// <returns>Dados do log</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LogEventoDTO>> ObterLogEvento(int id)
        {
            var logEvento = await _logEventoServico.ObterPorIdAsync(id);
            if (logEvento == null)
                return NotFound();

            return Ok(logEvento);
        }

        /// <summary>
        /// Cria um novo log de evento
        /// </summary>
        /// <param name="criarLogEventoDto">Dados do novo log</param>
        /// <returns>Dados do log criado</returns>
        [HttpPost]
        public async Task<ActionResult<LogEventoDTO>> CriarLogEvento(CriarLogEventoDTO criarLogEventoDto)
        {
            try
            {
                var logEvento = await _logEventoServico.CriarAsync(criarLogEventoDto);
                return CreatedAtAction(nameof(ObterLogEvento), new { id = logEvento.Id }, logEvento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um log de evento
        /// </summary>
        /// <param name="id">ID do log</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirLogEvento(int id)
        {
            try
            {
                await _logEventoServico.RemoverAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

