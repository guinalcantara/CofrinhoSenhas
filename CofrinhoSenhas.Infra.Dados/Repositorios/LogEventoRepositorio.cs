using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Repositorios
{
    /// <summary>
    /// Repositório para acesso aos dados de logs de eventos no banco de dados
    /// </summary>
    public class LogEventoRepositorio : ILogEventoRepositorio
    {
        private readonly ContextoAplicacao _contexto;

        public LogEventoRepositorio(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Busca todos os logs de eventos do banco ordenados por data
        /// </summary>
        public async Task<IEnumerable<LogEvento>> ObterLogEventosAsync()
        {
            return await _contexto.LogEventos
                .Include(l => l.Usuario)
                .OrderByDescending(l => l.DataInclusao)
                .ToListAsync();
        }

        /// <summary>
        /// Busca todos os logs de eventos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<LogEvento>> ObterLogEventosPorUsuarioAsync(int idUsuario)
        {
            return await _contexto.LogEventos
                .Where(l => l.IdUsuario == idUsuario)
                .Include(l => l.Usuario)
                .OrderByDescending(l => l.DataInclusao)
                .ToListAsync();
        }

        /// <summary>
        /// Busca um log de evento pelo ID incluindo relações
        /// </summary>
        /// <param name="id">ID do log</param>
        public async Task<LogEvento?> ObterPorIdAsync(int? id)
        {
            return await _contexto.LogEventos
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        /// <summary>
        /// Adiciona um novo log de evento no banco de dados
        /// </summary>
        /// <param name="logEvento">Entidade do log</param>
        public async Task<LogEvento> CriarAsync(LogEvento logEvento)
        {
            _contexto.Add(logEvento);
            await _contexto.SaveChangesAsync();
            return logEvento;
        }

        /// <summary>
        /// Atualiza um log de evento existente no banco
        /// </summary>
        /// <param name="logEvento">Entidade do log com dados atualizados</param>
        public async Task<LogEvento> AtualizarAsync(LogEvento logEvento)
        {
            _contexto.Update(logEvento);
            await _contexto.SaveChangesAsync();
            return logEvento;
        }

        /// <summary>
        /// Remove um log de evento do banco de dados
        /// </summary>
        /// <param name="logEvento">Entidade do log a ser removido</param>
        public async Task<LogEvento> RemoverAsync(LogEvento logEvento)
        {
            _contexto.Remove(logEvento);
            await _contexto.SaveChangesAsync();
            return logEvento;
        }
    }
}

