using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Repositorios
{
    /// <summary>
    /// Repositório para acesso aos dados de etiquetas no banco de dados
    /// </summary>
    public class EtiquetaRepositorio : IEtiquetaRepositorio
    {
        private readonly ContextoAplicacao _contexto;

        public EtiquetaRepositorio(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Busca todas as etiquetas do banco incluindo relações
        /// </summary>
        public async Task<IEnumerable<Etiqueta>> ObterEtiquetasAsync()
        {
            return await _contexto.Etiquetas
                .Include(e => e.Usuario)
                .Include(e => e.Senhas)
                .ToListAsync();
        }

        /// <summary>
        /// Busca todas as etiquetas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<Etiqueta>> ObterEtiquetasPorUsuarioAsync(int idUsuario)
        {
            return await _contexto.Etiquetas
                .Where(e => e.IdUsuario == idUsuario)
                .Include(e => e.Usuario)
                .Include(e => e.Senhas)
                .ToListAsync();
        }

        /// <summary>
        /// Busca uma etiqueta pelo ID incluindo relações
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        public async Task<Etiqueta?> ObterPorIdAsync(int? id)
        {
            return await _contexto.Etiquetas
                .Include(e => e.Usuario)
                .Include(e => e.Senhas)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Adiciona uma nova etiqueta no banco de dados
        /// </summary>
        /// <param name="etiqueta">Entidade da etiqueta</param>
        public async Task<Etiqueta> CriarAsync(Etiqueta etiqueta)
        {
            _contexto.Add(etiqueta);
            await _contexto.SaveChangesAsync();
            return etiqueta;
        }

        /// <summary>
        /// Atualiza uma etiqueta existente no banco
        /// </summary>
        /// <param name="etiqueta">Entidade da etiqueta com dados atualizados</param>
        public async Task<Etiqueta> AtualizarAsync(Etiqueta etiqueta)
        {
            _contexto.Update(etiqueta);
            await _contexto.SaveChangesAsync();
            return etiqueta;
        }

        /// <summary>
        /// Remove uma etiqueta do banco de dados
        /// </summary>
        /// <param name="etiqueta">Entidade da etiqueta a ser removida</param>
        public async Task<Etiqueta> RemoverAsync(Etiqueta etiqueta)
        {
            _contexto.Remove(etiqueta);
            await _contexto.SaveChangesAsync();
            return etiqueta;
        }
    }
}

