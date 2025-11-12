using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Dominio.Interfaces
{
    /// <summary>
    /// Interface para acesso aos dados de usuários no banco de dados
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Busca todos os usuários cadastrados
        /// </summary>
        Task<IEnumerable<Usuario>> ObterUsuariosAsync();
        
        /// <summary>
        /// Busca um usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        Task<Usuario?> ObterPorIdAsync(int? id);
        
        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        Task<Usuario?> ObterPorEmailAsync(string email);
        
        /// <summary>
        /// Cadastra um novo usuário no banco
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        Task<Usuario> CriarAsync(Usuario usuario);
        
        /// <summary>
        /// Atualiza os dados de um usuário existente
        /// </summary>
        /// <param name="usuario">Dados atualizados do usuário</param>
        Task<Usuario> AtualizarAsync(Usuario usuario);
        
        /// <summary>
        /// Remove um usuário do banco de dados
        /// </summary>
        /// <param name="usuario">Usuário a ser removido</param>
        Task<Usuario> RemoverAsync(Usuario usuario);
    }
}

