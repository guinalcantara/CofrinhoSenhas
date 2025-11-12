namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Classe base para todas as entidades do sistema
    /// </summary>
    public abstract class Entidade
    {
        /// <summary>
        /// Identificador único da entidade
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Data e hora quando o registro foi criado
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data e hora da última modificação do registro
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }
}

