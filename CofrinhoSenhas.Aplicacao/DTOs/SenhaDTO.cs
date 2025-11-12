namespace CofrinhoSenhas.Aplicacao.DTOs
{
    /// <summary>
    /// Dados da senha para transferência entre camadas
    /// </summary>
    public class SenhaDTO
    {
        /// <summary>
        /// ID único da senha
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Título ou nome da senha
        /// </summary>
        public string Titulo { get; set; } = string.Empty;
        
        /// <summary>
        /// URL do site ou aplicativo
        /// </summary>
        public string Url { get; set; } = string.Empty;
        
        /// <summary>
        /// Login ou usuário usado
        /// </summary>
        public string Login { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição ou observação adicional
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// ID do usuário dono da senha
        /// </summary>
        public int IdUsuario { get; set; }
        
        /// <summary>
        /// Nome do usuário dono
        /// </summary>
        public string? NomeUsuario { get; set; }
        
        /// <summary>
        /// ID da categoria da senha
        /// </summary>
        public int? IdCategoria { get; set; }
        
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string? NomeCategoria { get; set; }
        
        /// <summary>
        /// Lista de etiquetas associadas
        /// </summary>
        public List<string> Etiquetas { get; set; } = new List<string>();
        
        /// <summary>
        /// Data de criação da senha
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }
        
        /// <summary>
        /// Data da última alteração
        /// </summary>
        public DateTimeOffset DataAlteracao { get; set; }
    }

    /// <summary>
    /// Dados necessários para criar uma nova senha
    /// </summary>
    public class CriarSenhaDTO
    {
        /// <summary>
        /// Título da nova senha
        /// </summary>
        public string Titulo { get; set; } = string.Empty;
        
        /// <summary>
        /// URL do site
        /// </summary>
        public string Url { get; set; } = string.Empty;
        
        /// <summary>
        /// Login usado
        /// </summary>
        public string Login { get; set; } = string.Empty;
        
        /// <summary>
        /// Senha em texto (será criptografada)
        /// </summary>
        public string Senha { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição opcional
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// ID do usuário dono
        /// </summary>
        public int IdUsuario { get; set; }
        
        /// <summary>
        /// ID da categoria
        /// </summary>
        public int? IdCategoria { get; set; }
        
        /// <summary>
        /// Lista de IDs das etiquetas
        /// </summary>
        public List<int> IdEtiquetas { get; set; } = new List<int>();
    }

    /// <summary>
    /// Dados para atualizar uma senha existente
    /// </summary>
    public class AtualizarSenhaDTO
    {
        /// <summary>
        /// Novo título
        /// </summary>
        public string Titulo { get; set; } = string.Empty;
        
        /// <summary>
        /// Nova URL
        /// </summary>
        public string Url { get; set; } = string.Empty;
        
        /// <summary>
        /// Novo login
        /// </summary>
        public string Login { get; set; } = string.Empty;
        
        /// <summary>
        /// Nova senha (opcional, se vazio mantém a anterior)
        /// </summary>
        public string? Senha { get; set; }
        
        /// <summary>
        /// Nova descrição
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// Novo ID da categoria
        /// </summary>
        public int? IdCategoria { get; set; }
        
        /// <summary>
        /// Nova lista de IDs das etiquetas
        /// </summary>
        public List<int> IdEtiquetas { get; set; } = new List<int>();
    }

    /// <summary>
    /// Dados da senha com a senha descriptografada em texto
    /// </summary>
    public class SenhaDescriptografadaDTO
    {
        /// <summary>
        /// ID único da senha
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Título da senha
        /// </summary>
        public string Titulo { get; set; } = string.Empty;
        
        /// <summary>
        /// URL do site
        /// </summary>
        public string Url { get; set; } = string.Empty;
        
        /// <summary>
        /// Login usado
        /// </summary>
        public string Login { get; set; } = string.Empty;
        
        /// <summary>
        /// Senha em texto descriptografado
        /// </summary>
        public string Senha { get; set; } = string.Empty;
        
        /// <summary>
        /// Descrição adicional
        /// </summary>
        public string? Descricao { get; set; }
        
        /// <summary>
        /// ID do usuário dono
        /// </summary>
        public int IdUsuario { get; set; }
        
        /// <summary>
        /// ID da categoria
        /// </summary>
        public int? IdCategoria { get; set; }
        
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string? NomeCategoria { get; set; }
        
        /// <summary>
        /// Lista de etiquetas associadas
        /// </summary>
        public List<string> Etiquetas { get; set; } = new List<string>();
    }
}

