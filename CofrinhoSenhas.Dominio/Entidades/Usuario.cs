using CofrinhoSenhas.Dominio.Validacao;
using System.Collections.ObjectModel;

namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Representa um usuário do sistema
    /// </summary>
    public sealed class Usuario : Entidade
    {
        /// <summary>
        /// Nome completo do usuário
        /// </summary>
        public string Nome { get; private set; } = string.Empty;
        
        /// <summary>
        /// Email do usuário para login
        /// </summary>
        public string Email { get; private set; } = string.Empty;
        
        /// <summary>
        /// Senha do usuário criptografada com hash
        /// </summary>
        public string HashSenha { get; private set; } = string.Empty;
        
        /// <summary>
        /// Salt usado na criptografia da senha
        /// </summary>
        public string SaltSenha { get; private set; } = string.Empty;
        
        /// <summary>
        /// Data e hora do último login do usuário
        /// </summary>
        public DateTimeOffset? DataUltimoLogin { get; private set; }
        
        /// <summary>
        /// Indica se o usuário está ativo no sistema
        /// </summary>
        public bool Ativo { get; private set; }
        
        /// <summary>
        /// Lista de senhas cadastradas pelo usuário
        /// </summary>
        public ICollection<Senha> Senhas { get; set; } = new Collection<Senha>();

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="email">Email do usuário</param>
        /// <param name="hashSenha">Senha criptografada</param>
        /// <param name="saltSenha">Salt da senha</param>
        public Usuario(string nome, string email, string hashSenha, string saltSenha)
        {
            ValidarDominio(nome, email, hashSenha, saltSenha);
            Ativo = true;
        }

        /// <summary>
        /// Cria um usuário existente com todos os dados
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="email">Email do usuário</param>
        /// <param name="hashSenha">Senha criptografada</param>
        /// <param name="saltSenha">Salt da senha</param>
        /// <param name="ativo">Status do usuário</param>
        public Usuario(int id, string nome, string email, string hashSenha, string saltSenha, bool ativo)
        {
            ExcecaoValidacaoDominio.Quando(id < 0, "Valor do Id inválido.");
            Id = id;
            ValidarDominio(nome, email, hashSenha, saltSenha);
            Ativo = ativo;
        }

        /// <summary>
        /// Atualiza os dados básicos do usuário
        /// </summary>
        /// <param name="nome">Novo nome do usuário</param>
        /// <param name="email">Novo email do usuário</param>
        public void Atualizar(string nome, string email)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");
            ExcecaoValidacaoDominio.Quando(nome.Length < 2, "Nome inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(email), "Email inválido. Email é obrigatório");
            ExcecaoValidacaoDominio.Quando(!email.Contains("@"), "Formato de email inválido");

            Nome = nome;
            Email = email;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Atualiza a senha do usuário
        /// </summary>
        /// <param name="hashSenha">Nova senha criptografada</param>
        /// <param name="saltSenha">Novo salt da senha</param>
        public void AtualizarSenha(string hashSenha, string saltSenha)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(hashSenha), "Hash da senha inválido");
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(saltSenha), "Sal da senha inválido");

            HashSenha = hashSenha;
            SaltSenha = saltSenha;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Registra a data e hora do login do usuário
        /// </summary>
        public void DefinirUltimoLogin()
        {
            DataUltimoLogin = DateTimeOffset.Now;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Ativa o usuário no sistema
        /// </summary>
        public void Ativar()
        {
            Ativo = true;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Desativa o usuário no sistema
        /// </summary>
        public void Desativar()
        {
            Ativo = false;
            DataAlteracao = DateTimeOffset.Now;
        }

        /// <summary>
        /// Valida os dados do usuário
        /// </summary>
        private void ValidarDominio(string nome, string email, string hashSenha, string saltSenha)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");
            ExcecaoValidacaoDominio.Quando(nome.Length < 2, "Nome inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(email), "Email inválido. Email é obrigatório");
            ExcecaoValidacaoDominio.Quando(!email.Contains("@"), "Formato de email inválido");
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(hashSenha), "Hash da senha inválido");
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(saltSenha), "Sal da senha inválido");

            Nome = nome;
            Email = email;
            HashSenha = hashSenha;
            SaltSenha = saltSenha;
            DataInclusao = DateTimeOffset.Now;
            DataAlteracao = DateTimeOffset.Now;
        }
    }
}

