using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Dominio.Interfaces
{
    /// <summary>
    /// Interface para acesso aos dados de categorias no banco de dados
    /// </summary>
    public interface ICategoriaRepositorio
    {
        /// <summary>
        /// Busca todas as categorias cadastradas
        /// </summary>
        Task<IEnumerable<Categoria>> ObterCategoriasAsync();
        
        /// <summary>
        /// Busca as categorias de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        Task<IEnumerable<Categoria>> ObterCategoriasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Busca uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        Task<Categoria?> ObterPorIdAsync(int? id);
        
        /// <summary>
        /// Cadastra uma nova categoria no banco
        /// </summary>
        /// <param name="categoria">Dados da categoria</param>
        Task<Categoria> CriarAsync(Categoria categoria);
        
        /// <summary>
        /// Atualiza os dados de uma categoria existente
        /// </summary>
        /// <param name="categoria">Dados atualizados da categoria</param>
        Task<Categoria> AtualizarAsync(Categoria categoria);
        
        /// <summary>
        /// Remove uma categoria do banco de dados
        /// </summary>
        /// <param name="categoria">Categoria a ser removida</param>
        Task<Categoria> RemoverAsync(Categoria categoria);
    }
}

