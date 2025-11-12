using CofrinhoSenhas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CofrinhoSenhas.Infra.Dados.Contexto
{
    public class ContextoAplicacao : DbContext
    {
        public ContextoAplicacao(DbContextOptions<ContextoAplicacao> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Senha> Senhas { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<LogEvento> LogEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder construtor)
        {
            base.OnModelCreating(construtor);

            // Configuração da entidade Usuario
            construtor.Entity<Usuario>(entidade =>
            {
                entidade.ToTable("Usuarios");
                entidade.HasKey(u => u.Id);
                entidade.Property(u => u.Id).ValueGeneratedOnAdd();
                entidade.Property(u => u.DataInclusao).IsRequired();
                entidade.Property(u => u.DataAlteracao).IsRequired();
                entidade.Property(u => u.Nome).IsRequired().HasMaxLength(200);
                entidade.Property(u => u.Email).IsRequired().HasMaxLength(250);
                entidade.Property(u => u.HashSenha).IsRequired().HasMaxLength(500);
                entidade.Property(u => u.SaltSenha).IsRequired().HasMaxLength(500);
                entidade.Property(u => u.DataUltimoLogin).IsRequired(false);
                entidade.Property(u => u.Ativo).IsRequired();
                entidade.HasIndex(u => u.Email).IsUnique();
            });

            // Configuração da entidade Categoria
            construtor.Entity<Categoria>(entidade =>
            {
                entidade.ToTable("Categorias");
                entidade.HasKey(c => c.Id);
                entidade.Property(c => c.Id).ValueGeneratedOnAdd();
                entidade.Property(c => c.DataInclusao).IsRequired();
                entidade.Property(c => c.DataAlteracao).IsRequired();
                entidade.Property(c => c.Nome).IsRequired().HasMaxLength(150);
                entidade.Property(c => c.Descricao).IsRequired(false).HasMaxLength(500);
                entidade.Property(c => c.IdUsuario).IsRequired(false);
                entidade.HasOne(c => c.Usuario)
                      .WithMany()
                      .HasForeignKey(c => c.IdUsuario)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração da entidade Senha
            construtor.Entity<Senha>(entidade =>
            {
                entidade.ToTable("Senhas");
                entidade.HasKey(s => s.Id);
                entidade.Property(s => s.Id).ValueGeneratedOnAdd();
                entidade.Property(s => s.DataInclusao).IsRequired();
                entidade.Property(s => s.DataAlteracao).IsRequired();
                entidade.Property(s => s.Titulo).IsRequired().HasMaxLength(200);
                entidade.Property(s => s.Url).IsRequired().HasMaxLength(500);
                entidade.Property(s => s.Login).IsRequired().HasMaxLength(100);
                entidade.Property(s => s.SenhaCriptografada).IsRequired();
                entidade.Property(s => s.Descricao).IsRequired(false).HasMaxLength(1000);
                entidade.Property(s => s.IdUsuario).IsRequired();
                entidade.Property(s => s.IdCategoria).IsRequired(false);
                entidade.HasOne(s => s.Usuario)
                      .WithMany(u => u.Senhas)
                      .HasForeignKey(s => s.IdUsuario)
                      .OnDelete(DeleteBehavior.Cascade);
                entidade.HasOne(s => s.Categoria)
                      .WithMany()
                      .HasForeignKey(s => s.IdCategoria)
                      .OnDelete(DeleteBehavior.SetNull);
                entidade.HasMany(s => s.Etiquetas)
                      .WithMany(e => e.Senhas)
                      .UsingEntity(j => j.ToTable("SenhaEtiquetas"));
            });

            // Configuração da entidade Etiqueta
            construtor.Entity<Etiqueta>(entidade =>
            {
                entidade.ToTable("Etiquetas");
                entidade.HasKey(e => e.Id);
                entidade.Property(e => e.Id).ValueGeneratedOnAdd();
                entidade.Property(e => e.DataInclusao).IsRequired();
                entidade.Property(e => e.DataAlteracao).IsRequired();
                entidade.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entidade.Property(e => e.Descricao).IsRequired().HasMaxLength(500);
                entidade.Property(e => e.IdUsuario).IsRequired();
                entidade.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.IdUsuario)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade LogEvento
            construtor.Entity<LogEvento>(entidade =>
            {
                entidade.ToTable("LogEventos");
                entidade.HasKey(l => l.Id);
                entidade.Property(l => l.Id).ValueGeneratedOnAdd();
                entidade.Property(l => l.DataInclusao).IsRequired();
                entidade.Property(l => l.DataAlteracao).IsRequired();
                entidade.Property(l => l.Evento).IsRequired().HasMaxLength(100);
                entidade.Property(l => l.Descricao).IsRequired().HasMaxLength(1000);
                entidade.Property(l => l.EnderecoIP).IsRequired(false).HasMaxLength(45);
                entidade.Property(l => l.IdUsuario).IsRequired(false);
                entidade.HasOne(l => l.Usuario)
                      .WithMany()
                      .HasForeignKey(l => l.IdUsuario)
                      .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

