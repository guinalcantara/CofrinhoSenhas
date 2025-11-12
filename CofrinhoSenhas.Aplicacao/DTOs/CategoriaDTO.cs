namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Dados da categoria para transferência entre camadas
    /// </summary>
    public class CategoriaDTO
    {
        /// <summary>
        /// ID único da categoria
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição opcional da categoria
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// ID do usuário dono (null para categorias globais)
        /// </summary>
        public int? IdUsuario { get; set; }
        
        /// <summary>
        /// Nome do usuário dono
        /// </summary>
        public string? NomeUsuario { get; set; }
        
        /// <summary>
        /// Data de criação da categoria
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data da última alteração
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }

    /// <summary>
    /// Dados necessários para criar uma nova categoria
    /// </summary>
    public class CriarCategoriaDTO
    {
        /// <summary>
        /// Nome da nova categoria
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição opcional
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// ID do usuário dono (null para categorias globais)
        /// </summary>
        public int? IdUsuario { get; set; }
    }

    /// <summary>
    /// Dados para atualizar uma categoria existente
    /// </summary>
    public class AtualizarCategoriaDTO
    {
        /// <summary>
        /// Novo nome da categoria
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        
        /// <summary>
        /// Nova descrição
        /// </summary>
        public string? Descricao { get; set; }
    }
}

