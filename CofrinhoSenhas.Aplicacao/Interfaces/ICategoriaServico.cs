using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a lógica de negócio de categorias
    /// </summary>
    public interface ICategoriaServico : IService<CategoriaDTO>
    {
        /// <summary>
        /// Busca todas as categorias de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de categorias do usuário</returns>
        Task<IEnumerable<CategoriaDTO>> ObterCategoriasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="criarCategoriaDto">Dados da nova categoria</param>
        /// <returns>Dados da categoria criada</returns>
        Task<CategoriaDTO> CriarAsync(CriarCategoriaDTO criarCategoriaDto);
        
        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <param name="atualizarCategoriaDto">Novos dados da categoria</param>
        /// <returns>Dados da categoria atualizada</returns>
        Task<CategoriaDTO> AtualizarAsync(int id, AtualizarCategoriaDTO atualizarCategoriaDto);
    }
}

