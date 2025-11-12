using CofrinhoSenhas.Dominio.Validacao;

namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Representa uma etiqueta para marcar e organizar senhas
    /// </summary>
    public sealed class Etiqueta : Entidade
    {
        /// <summary>
        /// Nome da etiqueta
        /// </summary>
        public string Nome { get; private set; } = string.Empty;
        
        /// <summary>
        /// Descrição da etiqueta
        /// </summary>
        public string Descricao { get; private set; } = string.Empty;
        
        /// <summary>
        /// ID do usuário dono da etiqueta
        /// </summary>
        public int IdUsuario { get; private set; }
        
        /// <summary>
        /// Usuário dono da etiqueta
        /// </summary>
        public Usuario? Usuario { get; set; }
        
        /// <summary>
        /// Lista de senhas marcadas com esta etiqueta
        /// </summary>
        public ICollection<Senha> Senhas { get; set; } = new List<Senha>();

        /// <summary>
        /// Cria uma nova etiqueta
        /// </summary>
        /// <param name="nome">Nome da etiqueta</param>
        /// <param name="descricao">Descrição da etiqueta</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        public Etiqueta(string nome, string descricao, int idUsuario)
        {
            ValidarDominio(nome, descricao, idUsuario);
        }

        /// <summary>
        /// Cria uma etiqueta existente com todos os dados
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <param name="nome">Nome da etiqueta</param>
        /// <param name="descricao">Descrição da etiqueta</param>
        /// <param name="idUsuario">ID do usuário dono</param>
        public Etiqueta(int id, string nome, string descricao, int idUsuario)
        {
            ExcecaoValidacaoDominio.Quando(id < 0, "Valor do Id inválido.");
            Id = id;
            ValidarDominio(nome, descricao, idUsuario);
        }

        /// <summary>
        /// Atualiza os dados da etiqueta
        /// </summary>
        /// <param name="nome">Novo nome da etiqueta</param>
        /// <param name="descricao">Nova descrição da etiqueta</param>
        public void Atualizar(string nome, string descricao)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");
            ExcecaoValidacaoDominio.Quando(nome.Length < 2, "Nome inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(nome.Length > 100, "Nome inválido, muito longo, máximo 100 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é obrigatória");
            ExcecaoValidacaoDominio.Quando(descricao.Length > 500, "Descrição inválida, muito longa, máximo 500 caracteres");

            Nome = nome;
            Descricao = descricao;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Valida os dados da etiqueta
        /// </summary>
        private void ValidarDominio(string nome, string descricao, int idUsuario)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");
            ExcecaoValidacaoDominio.Quando(nome.Length < 2, "Nome inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(nome.Length > 100, "Nome inválido, muito longo, máximo 100 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é obrigatória");
            ExcecaoValidacaoDominio.Quando(descricao.Length > 500, "Descrição inválida, muito longa, máximo 500 caracteres");
            
            ExcecaoValidacaoDominio.Quando(idUsuario <= 0, "ID do usuário inválido");

            Nome = nome;
            Descricao = descricao;
            IdUsuario = idUsuario;
            DataInclusao = DateTimeOffset.Now;
            DataAlteracao = DateTimeOffset.Now;
        }
    }
}

