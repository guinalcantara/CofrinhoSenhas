namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Dados do log de evento para transferência entre camadas
    /// </summary>
    public class LogEventoDTO
    {
        /// <summary>
        /// ID único do log
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nome ou tipo do evento
        /// </summary>
        public string Evento { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição detalhada do evento
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
        
        /// <summary>
        /// Endereço IP de origem
        /// </summary>
        public string? EnderecoIP { get; set; }
        
        /// <summary>
        /// ID do usuário que causou o evento
        /// </summary>
        public int? IdUsuario { get; set; }
        
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string? NomeUsuario { get; set; }
        
        /// <summary>
        /// Data de criação do log
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data da última alteração
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }

    /// <summary>
    /// Dados necessários para criar um novo log de evento
    /// </summary>
    public class CriarLogEventoDTO
    {
        /// <summary>
        /// Nome do evento
        /// </summary>
        public string Evento { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição do evento
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
        
        /// <summary>
        /// Endereço IP de origem
        /// </summary>
        public string? EnderecoIP { get; set; }
        
        /// <summary>
        /// ID do usuário
        /// </summary>
        public int? IdUsuario { get; set; }
    }
}

