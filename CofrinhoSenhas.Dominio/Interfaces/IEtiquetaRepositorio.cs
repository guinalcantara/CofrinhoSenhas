using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Dominio.Interfaces
{
    /// <summary>
    /// Interface para acesso aos dados de etiquetas no banco de dados
    /// </summary>
    public interface IEtiquetaRepositorio
    {
        /// <summary>
        /// Busca todas as etiquetas cadastradas
        /// </summary>
        Task<IEnumerable<Etiqueta>> ObterEtiquetasAsync();
        
        /// <summary>
        /// Busca as etiquetas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        Task<IEnumerable<Etiqueta>> ObterEtiquetasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Busca uma etiqueta pelo ID
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        Task<Etiqueta?> ObterPorIdAsync(int? id);
        
        /// <summary>
        /// Cadastra uma nova etiqueta no banco
        /// </summary>
        /// <param name="etiqueta">Dados da etiqueta</param>
        Task<Etiqueta> CriarAsync(Etiqueta etiqueta);
        
        /// <summary>
        /// Atualiza os dados de uma etiqueta existente
        /// </summary>
        /// <param name="etiqueta">Dados atualizados da etiqueta</param>
        Task<Etiqueta> AtualizarAsync(Etiqueta etiqueta);
        
        /// <summary>
        /// Remove uma etiqueta do banco de dados
        /// </summary>
        /// <param name="etiqueta">Etiqueta a ser removida</param>
        Task<Etiqueta> RemoverAsync(Etiqueta etiqueta);
    }
}

