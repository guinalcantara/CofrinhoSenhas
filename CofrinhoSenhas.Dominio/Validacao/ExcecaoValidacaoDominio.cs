namespace CofrinhoSenhas.Dominio.Validacao
{
    /// <summary>
    /// Exceção lançada quando ocorre um erro de validação nas regras de domínio
    /// </summary>
    public class ExcecaoValidacaoDominio : Exception
    {
        /// <summary>
        /// Cria uma nova exceção de validação
        /// </summary>
        /// <param name="erro">Mensagem de erro</param>
        public ExcecaoValidacaoDominio(string erro) : base(erro)
        { }

        /// <summary>
        /// Lança uma exceção se a condição for verdadeira
        /// </summary>
        /// <param name="temErro">Condição que indica se há erro</param>
        /// <param name="erro">Mensagem de erro a ser lançada</param>
        public static void Quando(bool temErro, string erro)
        {
            if (temErro)
                throw new ExcecaoValidacaoDominio(erro);
        }
    }
}

