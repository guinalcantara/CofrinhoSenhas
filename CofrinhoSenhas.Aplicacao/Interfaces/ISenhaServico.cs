using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a lógica de negócio de senhas
    /// </summary>
    public interface ISenhaServico : IService<SenhaDTO>
    {
        /// <summary>
        /// Busca todas as senhas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de senhas do usuário</returns>
        Task<IEnumerable<SenhaDTO>> ObterSenhasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Busca todas as senhas de uma categoria específica
        /// </summary>
        /// <param name="idCategoria">ID da categoria</param>
        /// <returns>Lista de senhas da categoria</returns>
        Task<IEnumerable<SenhaDTO>> ObterSenhasPorCategoriaAsync(int idCategoria);
        
        /// <summary>
        /// Busca uma senha com o valor descriptografado
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <returns>Dados da senha com valor em texto ou null se não encontrada</returns>
        Task<SenhaDescriptografadaDTO?> ObterDescriptografadaPorIdAsync(int id);
        
        /// <summary>
        /// Cria uma nova senha
        /// </summary>
        /// <param name="criarSenhaDto">Dados da nova senha</param>
        /// <returns>Dados da senha criada</returns>
        Task<SenhaDTO> CriarAsync(CriarSenhaDTO criarSenhaDto);
        
        /// <summary>
        /// Atualiza uma senha existente
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <param name="atualizarSenhaDto">Novos dados da senha</param>
        /// <returns>Dados da senha atualizada</returns>
        Task<SenhaDTO> AtualizarAsync(int id, AtualizarSenhaDTO atualizarSenhaDto);
    }
}

