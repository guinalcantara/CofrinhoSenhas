namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Dados do usuário para transferência entre camadas
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// ID único do usuário
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nome completo do usuário
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Data do último login realizado
        /// </summary>
        public DateTimeOffset? DataUltimoLogin { get; set; }
        
        /// <summary>
        /// Indica se o usuário está ativo
        /// </summary>
        public bool Ativo { get; set; }
        
        /// <summary>
        /// Data de criação do usuário
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data da última alteração
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }

    /// <summary>
    /// Dados necessários para criar um novo usuário
    /// </summary>
    public class CriarUsuarioDTO
    {
        /// <summary>
        /// Nome do novo usuário
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Email do novo usuário
        /// </summary>
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Senha do novo usuário (será criptografada)
        /// </summary>
        public string Senha { get; set; } = string.Empty;
    }

    /// <summary>
    /// Dados para atualizar um usuário existente
    /// </summary>
    public class AtualizarUsuarioDTO
    {
        /// <summary>
        /// Novo nome do usuário
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Novo email do usuário
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }

    /// <summary>
    /// Dados para fazer login no sistema
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; } = string.Empty;
    }

    /// <summary>
    /// Dados para alterar a senha do usuário
    /// </summary>
    public class AlterarSenhaDTO
    {
        /// <summary>
        /// Senha atual do usuário
        /// </summary>
        public string SenhaAtual { get; set; } = string.Empty;
        
        /// <summary>
        /// Nova senha desejada
        /// </summary>
        public string NovaSenha { get; set; } = string.Empty;
    }
}

