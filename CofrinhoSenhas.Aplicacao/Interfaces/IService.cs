namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface base para todos os serviços da aplicação
    /// </summary>
    /// <typeparam name="T">Tipo do DTO usado pelo serviço</typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Busca um registro pelo ID
        /// </summary>
        /// <param name="id">ID do registro</param>
        /// <returns>Dados do registro ou null se não encontrado</returns>
        Task<T?> ObterPorIdAsync(int id);
        
        /// <summary>
        /// Busca todos os registros
        /// </summary>
        /// <returns>Lista com todos os registros</returns>
        Task<IEnumerable<T>> ObterTodosAsync();
        
        /// <summary>
        /// Remove um registro pelo ID
        /// </summary>
        /// <param name="id">ID do registro a ser removido</param>
        Task RemoverAsync(int id);
    }
}
