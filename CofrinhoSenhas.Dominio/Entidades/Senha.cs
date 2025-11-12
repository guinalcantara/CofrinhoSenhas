using CofrinhoSenhas.Dominio.Validacao;
using System.Collections.ObjectModel;

namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Representa uma senha armazenada no cofre
    /// </summary>
    public sealed class Senha : Entidade
    {
        /// <summary>
        /// Título ou nome identificador da senha
        /// </summary>
        public string Titulo { get; private set; } = string.Empty;
        
        /// <summary>
        /// URL do site ou aplicativo
        /// </summary>
        public string Url { get; private set; } = string.Empty;
        
        /// <summary>
        /// Login ou usuário usado no site
        /// </summary>
        public string Login { get; private set; } = string.Empty;
        
        /// <summary>
        /// Senha criptografada
        /// </summary>
        public string SenhaCriptografada { get; private set; } = string.Empty;
        
        /// <summary>
        /// Descrição ou observação opcional
        /// </summary>
        public string? Descricao { get; private set; }
        
        /// <summary>
        /// ID do usuário dono da senha
        /// </summary>
        public int IdUsuario { get; private set; }
        
        /// <summary>
        /// Usuário dono da senha
        /// </summary>
        public Usuario? Usuario { get; set; }
        
        /// <summary>
        /// ID da categoria da senha
        /// </summary>
        public int? IdCategoria { get; private set; }
        
        /// <summary>
        /// Categoria da senha
        /// </summary>
        public Categoria? Categoria { get; set; }
        
        /// <summary>
        /// Lista de etiquetas associadas à senha
        /// </summary>
        public ICollection<Etiqueta> Etiquetas { get; set; } = new Collection<Etiqueta>();

        /// <summary>
        /// Cria uma nova senha
        /// </summary>
        /// <param name="titulo">Título da senha</param>
        /// <param name="url">URL do site</param>
        /// <param name="login">Login usado</param>
        /// <param name="senhaCriptografada">Senha criptografada</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        /// <param name="descricao">Descrição opcional</param>
        /// <param name="idCategoria">ID da categoria</param>
        public Senha(string titulo, string url, string login, string senhaCriptografada, int idUsuario, string? descricao = null, int? idCategoria = null)
        {
            ValidarDominio(titulo, url, login, senhaCriptografada, idUsuario, descricao);
            IdCategoria = idCategoria;
        }

        /// <summary>
        /// Cria uma senha existente com todos os dados
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <param name="titulo">Título da senha</param>
        /// <param name="url">URL do site</param>
        /// <param name="login">Login usado</param>
        /// <param name="senhaCriptografada">Senha criptografada</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        /// <param name="descricao">Descrição opcional</param>
        /// <param name="idCategoria">ID da categoria</param>
        public Senha(int id, string titulo, string url, string login, string senhaCriptografada, int idUsuario, string? descricao = null, int? idCategoria = null)
        {
            ExcecaoValidacaoDominio.Quando(id < 0, "Valor do Id inválido.");
            Id = id;
            ValidarDominio(titulo, url, login, senhaCriptografada, idUsuario, descricao);
            IdCategoria = idCategoria;
        }

        /// <summary>
        /// Atualiza os dados da senha
        /// </summary>
        /// <param name="titulo">Novo título</param>
        /// <param name="url">Nova URL</param>
        /// <param name="login">Novo login</param>
        /// <param name="senhaCriptografada">Nova senha criptografada</param>
        /// <param name="descricao">Nova descrição</param>
        /// <param name="idCategoria">Novo ID da categoria</param>
        public void Atualizar(string titulo, string url, string login, string senhaCriptografada, string? descricao = null, int? idCategoria = null)
        {
            ValidarDominio(titulo, url, login, senhaCriptografada, IdUsuario, descricao);
            IdCategoria = idCategoria;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Valida os dados da senha
        /// </summary>
        private void ValidarDominio(string titulo, string url, string login, string senhaCriptografada, int idUsuario, string? descricao)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(titulo), "Título inválido. Título é obrigatório");
            ExcecaoValidacaoDominio.Quando(titulo.Length < 2, "Título inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(titulo.Length > 200, "Título inválido, muito longo, máximo 200 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(url), "URL inválida. URL é obrigatória");
            ExcecaoValidacaoDominio.Quando(url.Length > 500, "URL inválida, muito longa, máximo 500 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(login), "Login inválido. Login é obrigatório");
            ExcecaoValidacaoDominio.Quando(login.Length > 100, "Login inválido, muito longo, máximo 100 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(senhaCriptografada), "Senha inválida. Senha é obrigatória");
            
            ExcecaoValidacaoDominio.Quando(idUsuario <= 0, "ID do usuário inválido");
            
            if (!string.IsNullOrEmpty(descricao))
            {
                ExcecaoValidacaoDominio.Quando(descricao.Length > 1000, "Descrição inválida, muito longa, máximo 1000 caracteres");
            }

            Titulo = titulo;
            Url = url;
            Login = login;
            SenhaCriptografada = senhaCriptografada;
            IdUsuario = idUsuario;
            Descricao = descricao;
            DataInclusao = DataInclusao == default ? DateTimeOffset.Now : DataInclusao;
            DataAlteracao = DateTimeOffset.Now;
        }
    }
}

