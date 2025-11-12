using AutoMapper;
using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;

namespace CofrinhoSenhas.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio de logs de eventos
    /// </summary>
    public class LogEventoServico : ILogEventoServico
    {
        private readonly ILogEventoRepositorio _logEventoRepositorio;
        private readonly IMapper _mapeador;

        public LogEventoServico(ILogEventoRepositorio logEventoRepositorio, IMapper mapeador)
        {
            _logEventoRepositorio = logEventoRepositorio;
            _mapeador = mapeador;
        }

        /// <summary>
        /// Busca todos os logs de eventos cadastrados
        /// </summary>
        public async Task<IEnumerable<LogEventoDTO>> ObterTodosAsync()
        {
            IEnumerable<LogEvento> logEventos = await _logEventoRepositorio.ObterLogEventosAsync();
            return _mapeador.Map<IEnumerable<LogEventoDTO>>(logEventos);
        }

        /// <summary>
        /// Busca todos os logs de eventos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<LogEventoDTO>> ObterLogEventosPorUsuarioAsync(int idUsuario)
        {
            IEnumerable<LogEvento> logEventos = await _logEventoRepositorio.ObterLogEventosPorUsuarioAsync(idUsuario);
            return _mapeador.Map<IEnumerable<LogEventoDTO>>(logEventos);
        }

        /// <summary>
        /// Busca um log de evento pelo ID
        /// </summary>
        /// <param name="id">ID do log</param>
        public async Task<LogEventoDTO?> ObterPorIdAsync(int id)
        {
            LogEvento? logEvento = await _logEventoRepositorio.ObterPorIdAsync(id);
            return logEvento != null ? _mapeador.Map<LogEventoDTO>(logEvento) : null;
        }

        /// <summary>
        /// Cria um novo log de evento no sistema
        /// </summary>
        /// <param name="criarLogEventoDto">Dados do novo log</param>
        public async Task<LogEventoDTO> CriarAsync(CriarLogEventoDTO criarLogEventoDto)
        {
            LogEvento logEvento = new LogEvento(
                criarLogEventoDto.Evento,
                criarLogEventoDto.Descricao,
                criarLogEventoDto.EnderecoIP,
                criarLogEventoDto.IdUsuario
            );

            LogEvento logEventoCriado = await _logEventoRepositorio.CriarAsync(logEvento);
            return _mapeador.Map<LogEventoDTO>(logEventoCriado);
        }

        /// <summary>
        /// Atualiza um log de evento existente (nota: logs geralmente são imutáveis)
        /// </summary>
        /// <param name="id">ID do log</param>
        /// <param name="atualizarLogEventoDto">Novos dados do log</param>
        public async Task<LogEventoDTO> AtualizarAsync(int id, LogEventoDTO atualizarLogEventoDto)
        {
            LogEvento? logEvento = await _logEventoRepositorio.ObterPorIdAsync(id);
            if (logEvento == null)
                throw new ArgumentException("Log de evento não encontrado");

            // LogEvento é imutável após criação, mas mantemos o método para consistência da interface
            LogEvento logEventoAtualizado = await _logEventoRepositorio.AtualizarAsync(logEvento);
            return _mapeador.Map<LogEventoDTO>(logEventoAtualizado);
        }

        /// <summary>
        /// Remove um log de evento do sistema
        /// </summary>
        /// <param name="id">ID do log</param>
        public async Task RemoverAsync(int id)
        {
            LogEvento? logEvento = await _logEventoRepositorio.ObterPorIdAsync(id);
            if (logEvento == null)
                throw new ArgumentException("Log de evento não encontrado");

            await _logEventoRepositorio.RemoverAsync(logEvento);
        }
    }
}

