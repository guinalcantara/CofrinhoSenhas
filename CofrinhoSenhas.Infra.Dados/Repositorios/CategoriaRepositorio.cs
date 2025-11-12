using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Repositorios
{
    /// <summary>
    /// Repositório para acesso aos dados de categorias no banco de dados
    /// </summary>
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ContextoAplicacao _contexto;

        public CategoriaRepositorio(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Busca todas as categorias do banco incluindo relações
        /// </summary>
        public async Task<IEnumerable<Categoria>> ObterCategoriasAsync()
        {
            return await _contexto.Categorias.Include(c => c.Usuario).ToListAsync();
        }

        /// <summary>
        /// Busca todas as categorias de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<Categoria>> ObterCategoriasPorUsuarioAsync(int idUsuario)
        {
            return await _contexto.Categorias
                .Where(c => c.IdUsuario == idUsuario)
                .Include(c => c.Usuario)
                .ToListAsync();
        }

        /// <summary>
        /// Busca uma categoria pelo ID incluindo relações
        /// </summary>
        /// <param name="id">ID da categoria</param>
        public async Task<Categoria?> ObterPorIdAsync(int? id)
        {
            return await _contexto.Categorias
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adiciona uma nova categoria no banco de dados
        /// </summary>
        /// <param name="categoria">Entidade da categoria</param>
        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            _contexto.Add(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }

        /// <summary>
        /// Atualiza uma categoria existente no banco
        /// </summary>
        /// <param name="categoria">Entidade da categoria com dados atualizados</param>
        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            _contexto.Update(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }

        /// <summary>
        /// Remove uma categoria do banco de dados
        /// </summary>
        /// <param name="categoria">Entidade da categoria a ser removida</param>
        public async Task<Categoria> RemoverAsync(Categoria categoria)
        {
            _contexto.Remove(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }
    }
}

