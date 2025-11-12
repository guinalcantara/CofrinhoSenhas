using CofrinhoSenhas.Dominio.Validacao;

namespace CofrinhoSenhas.Dominio.Entidades
{
    /// <summary>
    /// Representa um registro de evento no sistema para auditoria
    /// </summary>
    public sealed class LogEvento : Entidade
    {
        /// <summary>
        /// Nome ou tipo do evento registrado
        /// </summary>
        public string Evento { get; private set; } = string.Empty;
        
        /// <summary>
        /// Descrição detalhada do evento
        /// </summary>
        public string Descricao { get; private set; } = string.Empty;
        
        /// <summary>
        /// Endereço IP de onde o evento foi originado
        /// </summary>
        public string? EnderecoIP { get; private set; }
        
        /// <summary>
        /// ID do usuário que causou o evento
        /// </summary>
        public int? IdUsuario { get; private set; }
        
        /// <summary>
        /// Usuário que causou o evento
        /// </summary>
        public Usuario? Usuario { get; set; }

        /// <summary>
        /// Cria um novo registro de evento
        /// </summary>
        /// <param name="evento">Nome do evento</param>
        /// <param name="descricao">Descrição do evento</param>
        /// <param name="enderecoIP">IP de origem</param>
        /// <param name="idUsuario">ID do usuário</param>
        public LogEvento(string evento, string descricao, string? enderecoIP = null, int? idUsuario = null)
        {
            ValidarDominio(evento, descricao);
            EnderecoIP = enderecoIP;
            IdUsuario = idUsuario;
        }

        /// <summary>
        /// Cria um log de evento existente com todos os dados
        /// </summary>
        /// <param name="id">ID do log</param>
        /// <param name="evento">Nome do evento</param>
        /// <param name="descricao">Descrição do evento</param>
        /// <param name="enderecoIP">IP de origem</param>
        /// <param name="idUsuario">ID do usuário</param>
        public LogEvento(int id, string evento, string descricao, string? enderecoIP = null, int? idUsuario = null)
        {
            ExcecaoValidacaoDominio.Quando(id < 0, "Valor do Id inválido.");
            Id = id;
            ValidarDominio(evento, descricao);
            EnderecoIP = enderecoIP;
            IdUsuario = idUsuario;
        }

        /// <summary>
        /// Valida os dados do log de evento
        /// </summary>
        private void ValidarDominio(string evento, string descricao)
        {
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(evento), "Evento inválido. Evento é obrigatório");
            ExcecaoValidacaoDominio.Quando(evento.Length < 2, "Evento inválido, muito curto, mínimo 2 caracteres");
            ExcecaoValidacaoDominio.Quando(evento.Length > 100, "Evento inválido, muito longo, máximo 100 caracteres");
            
            ExcecaoValidacaoDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é obrigatória");
            ExcecaoValidacaoDominio.Quando(descricao.Length > 1000, "Descrição inválida, muito longa, máximo 1000 caracteres");

            Evento = evento;
            Descricao = descricao;
            DataInclusao = DateTimeOffset.Now;
            DataAlteracao = DateTimeOffset.Now;
        }
    }
}

