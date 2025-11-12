using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a lógica de negócio de etiquetas
    /// </summary>
    public interface IEtiquetaServico : IService<EtiquetaDTO>
    {
        /// <summary>
        /// Busca todas as etiquetas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        /// <returns>Lista de etiquetas do usuário</returns>
        Task<IEnumerable<EtiquetaDTO>> ObterEtiquetasPorUsuarioAsync(int idUsuario);
        
        /// <summary>
        /// Cria uma nova etiqueta
        /// </summary>
        /// <param name="criarEtiquetaDto">Dados da nova etiqueta</param>
        /// <returns>Dados da etiqueta criada</returns>
        Task<EtiquetaDTO> CriarAsync(CriarEtiquetaDTO criarEtiquetaDto);
        
        /// <summary>
        /// Atualiza uma etiqueta existente
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <param name="atualizarEtiquetaDto">Novos dados da etiqueta</param>
        /// <returns>Dados da etiqueta atualizada</returns>
        Task<EtiquetaDTO> AtualizarAsync(int id, AtualizarEtiquetaDTO atualizarEtiquetaDto);
    }
}

