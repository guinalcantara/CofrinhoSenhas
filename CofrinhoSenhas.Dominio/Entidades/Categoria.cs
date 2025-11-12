using CofrinhoSenhas.Dominio.Validacao;

namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Representa uma categoria para organizar senhas
    /// </summary>
    public sealed class Categoria : Entidade
    {
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome { get; private set; } = string.Empty;
        
        /// <summary>
        /// Descrição opcional da categoria
        /// </summary>
        public string? Descricao { get; private set; }
        
        /// <summary>
        /// ID do usuário dono da categoria (null para categorias globais)
        /// </summary>
        public int? IdUsuario { get; private set; }
        
        /// <summary>
        /// Usuário dono da categoria
        /// </summary>
        public Usuario? Usuario { get; set; }

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="nome">Nome da categoria</param>
        /// <param name="descricao">Descrição da categoria</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        public Categoria(string nome, string? descricao = null, int? idUsuario = null)
        {
            ValidarDominio(nome, descricao);
            IdUsuario = idUsuario;
        }

        /// <summary>
        /// Cria uma categoria existente com todos os dados
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <param name="nome">Nome da categoria</param>
        /// <param name="descricao">Descrição da categoria</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        public Categoria(int id, string nome, string? descricao = null, int? idUsuario = null)
        {
            ExcecaoValidacaoDominio.Quando(id < 0, "Valor do Id inválido.");
            Id = id;
            ValidarDominio(nome, descricao);
            IdUsuario = idUsuario;
        }

        /// <summary>
        /// Atualiza os dados da categoria
        /// </summary>
        /// <param name="nome">Novo nome da categoria</param>
        /// <param name="descricao">Nova descrição da categoria</param>
        public void Atualizar(string nome, string? descricao = null)
        {
            ValidarDominio(nome, descricao);
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Valida os dados da categoria
        /// </summary>
        private void ValidarDominio(string nome, string? descricao)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");
            ExcecaoValidacaoDominio.Quando(nome.Length < 2, "Nome inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(nome.Length > 150, "Nome inválido, muito longo, máximo 150 caracteres");
            
            if (!string.IsNullOrEmpty(descricao))
            {
                ExcecaoValidacaoDominio.Quando(descricao.Length > 500, "Descrição inválida, muito longa, máximo 500 caracteres");
            }

            Nome = nome;
            Descricao = descricao;
            DataInclusao = DataInclusao == default ? DateTimeOffset.Now : DataInclusao;
            DataAlteracao = DateTimeOffset.Now;
        }
    }
}

