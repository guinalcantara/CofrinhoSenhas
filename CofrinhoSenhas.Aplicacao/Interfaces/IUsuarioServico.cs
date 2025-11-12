using CofrinhoSenhas.Aplicacao.DTOs;

namespace CofrinhoSenhas.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a lógica de negócio de usuários
    /// </summary>
    public interface IUsuarioServico : IService<UsuarioDTO>
    {
        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Dados do usuário ou null se não encontrado</returns>
        Task<UsuarioDTO?> ObterPorEmailAsync(string email);
        
        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="criarUsuarioDto">Dados do novo usuário</param>
        /// <returns>Dados do usuário criado</returns>
        Task<UsuarioDTO> CriarAsync(CriarUsuarioDTO criarUsuarioDto);
        
        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="atualizarUsuarioDto">Novos dados do usuário</param>
        /// <returns>Dados do usuário atualizado</returns>
        Task<UsuarioDTO> AtualizarAsync(int id, AtualizarUsuarioDTO atualizarUsuarioDto);
        
        /// <summary>
        /// Autentica um usuário no sistema
        /// </summary>
        /// <param name="loginDto">Email e senha do usuário</param>
        /// <returns>Dados do usuário autenticado ou null se inválido</returns>
        Task<UsuarioDTO?> AutenticarAsync(LoginDTO loginDto);
        
        /// <summary>
        /// Altera a senha de um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="senhaAtual">Senha atual do usuário</param>
        /// <param name="novaSenha">Nova senha desejada</param>
        /// <returns>True se alterado com sucesso, False se senha atual incorreta</returns>
        Task<bool> AlterarSenhaAsync(int id, string senhaAtual, string novaSenha);
    }
}

