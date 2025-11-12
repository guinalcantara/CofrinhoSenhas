namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Dados da etiqueta para transferência entre camadas
    /// </summary>
    public class EtiquetaDTO
    {
        /// <summary>
        /// ID único da etiqueta
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nome da etiqueta
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição da etiqueta
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
        
        /// <summary>
        /// ID do usuário dono da etiqueta
        /// </summary>
        public int IdUsuario { get; set; }
        
        /// <summary>
        /// Nome do usuário dono
        /// </summary>
        public string? NomeUsuario { get; set; }
        
        /// <summary>
        /// Data de criação da etiqueta
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data da última alteração
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }

    /// <summary>
    /// Dados necessários para criar uma nova etiqueta
    /// </summary>
    public class CriarEtiquetaDTO
    {
        /// <summary>
        /// Nome da nova etiqueta
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição da etiqueta
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
        
        /// <summary>
        /// ID do usuário dono
        /// </summary>
        public int IdUsuario { get; set; }
    }

    /// <summary>
    /// Dados para atualizar uma etiqueta existente
    /// </summary>
    public class AtualizarEtiquetaDTO
    {
        /// <summary>
        /// Novo nome da etiqueta
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Nova descrição
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
    }
}

