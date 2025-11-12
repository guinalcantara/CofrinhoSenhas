using CofrinhoSenhas.Aplicacao.Interfaces;
using CofrinhoSenhas.Aplicacao.Mapeamentos;
using CofrinhoSenhas.Aplicacao.Servicos;
using CofrinhoSenhas.Dominio.Interfaces;
using CofrinhoSenhas.Infra.Dados.Contexto;
using CofrinhoSenhas.Infra.Dados.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CofrinhoSenhas.Infra.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarInfraestrutura(this IServiceCollection servicos, IConfiguration configuracao)
        {
            // Contexto do Banco de Dados
            servicos.AddDbContext<ContextoAplicacao>(opcoes =>
                opcoes.UseMySql(configuracao.GetConnectionString("ConexaoPadrao"),
                    ServerVersion.AutoDetect(configuracao.GetConnectionString("ConexaoPadrao"))));

            // Repositórios
            servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            servicos.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            servicos.AddScoped<ISenhaRepositorio, SenhaRepositorio>();
            servicos.AddScoped<IEtiquetaRepositorio, EtiquetaRepositorio>();
            servicos.AddScoped<ILogEventoRepositorio, LogEventoRepositorio>();

            // Serviços
            servicos.AddScoped<IUsuarioServico, UsuarioServico>();
            servicos.AddScoped<ICategoriaServico, CategoriaServico>();
            servicos.AddScoped<ISenhaServico, SenhaServico>();
            servicos.AddScoped<IEtiquetaServico, EtiquetaServico>();
            servicos.AddScoped<ILogEventoServico, LogEventoServico>();
            servicos.AddScoped<ITokenServico, TokenServico>();

            // AutoMapper
            servicos.AddAutoMapper(typeof(MapeamentoDTO));

            return servicos;
        }
    }
}

