using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Dominio.Interfaces
{
    /// <summary>
    /// Interface para acesso aos dados de senhas no banco de dados
    /// </summary>
    public interface ISenhaRepositorio
    {
        /// <summary>
        /// Busca todas as senhas cadastradas
        /// </summary>
        Task<IEnumerable<Senha>> ObterSenhasAsync();
        
        /// <summary>
        /// Busca as senhas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        Task<IEnumerable<Senha>> ObterSenhasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Busca as senhas de uma categoria específica
        /// </summary>
        /// <param name="idCategoria">ID da categoria</param>
        Task<IEnumerable<Senha>> ObterSenhasPorCategoriaAsync(int idCategoria);
        
        /// <summary>
        /// Busca uma senha pelo ID
        /// </summary>
        /// <param name="id">ID da senha</param>
        Task<Senha?> ObterPorIdAsync(int? id);
        
        /// <summary>
        /// Cadastra uma nova senha no banco
        /// </summary>
        /// <param name="senha">Dados da senha</param>
        Task<Senha> CriarAsync(Senha senha);
        
        /// <summary>
        /// Atualiza os dados de uma senha existente
        /// </summary>
        /// <param name="senha">Dados atualizados da senha</param>
        Task<Senha> AtualizarAsync(Senha senha);
        
        /// <summary>
        /// Remove uma senha do banco de dados
        /// </summary>
        /// <param name="senha">Senha a ser removida</param>
        Task<Senha> RemoverAsync(Senha senha);
    }
}

