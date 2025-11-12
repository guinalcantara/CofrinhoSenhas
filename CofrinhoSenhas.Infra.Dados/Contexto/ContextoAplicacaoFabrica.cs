using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CofrinhoSenhas.Infra.Dados.Contexto
{
    public class ContextoAplicacaoFabrica : IDesignTimeDbContextFactory<ContextoAplicacao>
    {
        public ContextoAplicacao CreateDbContext(string[] args)
        {
            // Obter a string de conexão do appsettings.json do projeto WebAPI
            var caminhoBase = Path.Combine(Directory.GetCurrentDirectory(), "..", "CofrinhoSenhas.WebAPI");
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(caminhoBase)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var stringConexao = configuracao.GetConnectionString("ConexaoPadrao");

            var construtorOpcoes = new DbContextOptionsBuilder<ContextoAplicacao>();
            construtorOpcoes.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));

            return new ContextoAplicacao(construtorOpcoes.Options);
        }
    }
}
