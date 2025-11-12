namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Resposta retornada após um login bem-sucedido
    /// </summary>
    public class LoginRespostaDTO
    {
        /// <summary>
        /// Dados do usuário logado
        /// </summary>
        public UsuarioDTO Usuario { get; set; } = null!;
        
        /// <summary>
        /// Token JWT para autenticação nas próximas requisições
        /// </summary>
        public string Token { get; set; } = string.Empty;
        
        /// <summary>
        /// Data e hora quando o token irá expirar
        /// </summary>
        public DateTime DataExpiracao { get; set; }
    }
}
