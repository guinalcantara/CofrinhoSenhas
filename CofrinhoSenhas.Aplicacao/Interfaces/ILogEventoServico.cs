using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a lógica de negócio de logs de eventos
    /// </summary>
    public interface ILogEventoServico : IService<LogEventoDTO>
    {
        /// <summary>
        /// Busca todos os logs de eventos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de logs do usuário</returns>
        Task<IEnumerable<LogEventoDTO>> ObterLogEventosPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Cria um novo log de evento
        /// </summary>
        /// <param name="criarLogEventoDto">Dados do novo log</param>
        /// <returns>Dados do log criado</returns>
        Task<LogEventoDTO> CriarAsync(CriarLogEventoDTO criarLogEventoDto);
        
        /// <summary>
        /// Atualiza um log de evento existente
        /// </summary>
        /// <param name="id">ID do log</param>
        /// <param name="atualizarLogEventoDto">Novos dados do log</param>
        /// <returns>Dados do log atualizado</returns>
        Task<LogEventoDTO> AtualizarAsync(int id, LogEventoDTO atualizarLogEventoDto);
    }
}

