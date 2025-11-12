using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Repositorios
{
    /// <summary>
    /// Repositório para acesso aos dados de usuários no banco de dados
    /// </summary>
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ContextoAplicacao _contexto;

        public UsuarioRepositorio(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Busca todos os usuários do banco
        /// </summary>
        public async Task<IEnumerable<Usuario>> ObterUsuariosAsync()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        /// <summary>
        /// Busca um usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        public async Task<Usuario?> ObterPorIdAsync(int? id)
        {
            return await _contexto.Usuarios.FindAsync(id);
        }

        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Adiciona um novo usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Entidade do usuário</param>
        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            _contexto.Add(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Atualiza um usuário existente no banco
        /// </summary>
        /// <param name="usuario">Entidade do usuário com dados atualizados</param>
        public async Task<Usuario> AtualizarAsync(Usuario usuario)
        {
            _contexto.Update(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Remove um usuário do banco de dados
        /// </summary>
        /// <param name="usuario">Entidade do usuário a ser removido</param>
        public async Task<Usuario> RemoverAsync(Usuario usuario)
        {
            _contexto.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }
    }
}

