using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Dominio.Interfaces
{
    /// <summary>
    /// Interface para acesso aos dados de logs de eventos no banco de dados
    /// </summary>
    public interface ILogEventoRepositorio
    {
        /// <summary>
        /// Busca todos os logs de eventos cadastrados
        /// </summary>
        Task<IEnumerable<LogEvento>> ObterLogEventosAsync();
        
        /// <summary>
        /// Busca os logs de eventos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        Task<IEnumerable<LogEvento>> ObterLogEventosPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Busca um log de evento pelo ID
        /// </summary>
        /// <param name="id">ID do log</param>
        Task<LogEvento?> ObterPorIdAsync(int? id);
        
        /// <summary>
        /// Cadastra um novo log de evento no banco
        /// </summary>
        /// <param name="logEvento">Dados do log</param>
        Task<LogEvento> CriarAsync(LogEvento logEvento);
        
        /// <summary>
        /// Atualiza os dados de um log de evento existente
        /// </summary>
        /// <param name="logEvento">Dados atualizados do log</param>
        Task<LogEvento> AtualizarAsync(LogEvento logEvento);
        
        /// <summary>
        /// Remove um log de evento do banco de dados
        /// </summary>
        /// <param name="logEvento">Log a ser removido</param>
        Task<LogEvento> RemoverAsync(LogEvento logEvento);
    }
}

