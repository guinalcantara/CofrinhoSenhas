using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Repositorios
{
    /// <summary>
    /// Repositório para acesso aos dados de senhas no banco de dados
    /// </summary>
    public class SenhaRepositorio : ISenhaRepositorio
    {
        private readonly ContextoAplicacao _contexto;

        public SenhaRepositorio(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Busca todas as senhas do banco incluindo relações
        /// </summary>
        public async Task<IEnumerable<Senha>> ObterSenhasAsync()
        {
            return await _contexto.Senhas
                .Include(s => s.Usuario)
                .Include(s => s.Categoria)
                .Include(s => s.Etiquetas)
                .ToListAsync();
        }

        /// <summary>
        /// Busca todas as senhas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<Senha>> ObterSenhasPorUsuarioAsync(int idUsuario)
        {
            return await _contexto.Senhas
                .Where(s => s.IdUsuario == idUsuario)
                .Include(s => s.Usuario)
                .Include(s => s.Categoria)
                .Include(s => s.Etiquetas)
                .ToListAsync();
        }

        /// <summary>
        /// Busca todas as senhas de uma categoria específica
        /// </summary>
        /// <param name="idCategoria">ID da categoria</param>
        public async Task<IEnumerable<Senha>> ObterSenhasPorCategoriaAsync(int idCategoria)
        {
            return await _contexto.Senhas
                .Where(s => s.IdCategoria == idCategoria)
                .Include(s => s.Usuario)
                .Include(s => s.Categoria)
                .Include(s => s.Etiquetas)
                .ToListAsync();
        }

        /// <summary>
        /// Busca uma senha pelo ID incluindo relações
        /// </summary>
        /// <param name="id">ID da senha</param>
        public async Task<Senha?> ObterPorIdAsync(int? id)
        {
            return await _contexto.Senhas
                .Include(s => s.Usuario)
                .Include(s => s.Categoria)
                .Include(s => s.Etiquetas)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Adiciona uma nova senha no banco de dados
        /// </summary>
        /// <param name="senha">Entidade da senha</param>
        public async Task<Senha> CriarAsync(Senha senha)
        {
            _contexto.Add(senha);
            await _contexto.SaveChangesAsync();
            return senha;
        }

        /// <summary>
        /// Atualiza uma senha existente no banco
        /// </summary>
        /// <param name="senha">Entidade da senha com dados atualizados</param>
        public async Task<Senha> AtualizarAsync(Senha senha)
        {
            _contexto.Update(senha);
            await _contexto.SaveChangesAsync();
            return senha;
        }

        /// <summary>
        /// Remove uma senha do banco de dados
        /// </summary>
        /// <param name="senha">Entidade da senha a ser removida</param>
        public async Task<Senha> RemoverAsync(Senha senha)
        {
            _contexto.Remove(senha);
            await _contexto.SaveChangesAsync();
            return senha;
        }
    }
}

