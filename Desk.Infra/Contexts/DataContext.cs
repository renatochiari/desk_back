using Desk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desk.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Chamado>? Chamados { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Empresa>? Empresas { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Empresa>().Property(x => x.Id);
            modelBuilder.Entity<Empresa>().Property(x => x.Documento).HasMaxLength(14).HasColumnType("varchar(14)");
            modelBuilder.Entity<Empresa>().Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Empresa>().Property(x => x.Rua).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Empresa>().Property(x => x.Numero).HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<Empresa>().Property(x => x.Complemento).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Empresa>().Property(x => x.Bairro).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Empresa>().Property(x => x.Cep).HasMaxLength(8).HasColumnType("varchar(8)");
            modelBuilder.Entity<Empresa>().Property(x => x.Cidade).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Empresa>().Property(x => x.Estado).HasMaxLength(2).HasColumnType("varchar(2)");
            modelBuilder.Entity<Empresa>().Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Property(x => x.Id);
            modelBuilder.Entity<Cliente>().Property(x => x.Documento).HasMaxLength(14).HasColumnType("varchar(14)");
            modelBuilder.Entity<Cliente>().Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Cliente>().Property(x => x.Rua).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Cliente>().Property(x => x.Numero).HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<Cliente>().Property(x => x.Complemento).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Cliente>().Property(x => x.Bairro).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Cliente>().Property(x => x.Cep).HasMaxLength(8).HasColumnType("varchar(8)");
            modelBuilder.Entity<Cliente>().Property(x => x.Cidade).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Cliente>().Property(x => x.Estado).HasMaxLength(2).HasColumnType("varchar(2)");
            modelBuilder.Entity<Cliente>().Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Cliente>().Property(x => x.EmpresaId);

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Documento).HasMaxLength(14).HasColumnType("varchar(14)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Usuario>().Property(x => x.Rua).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Usuario>().Property(x => x.Numero).HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<Usuario>().Property(x => x.Complemento).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Usuario>().Property(x => x.Bairro).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Usuario>().Property(x => x.Cep).HasMaxLength(8).HasColumnType("varchar(8)");
            modelBuilder.Entity<Usuario>().Property(x => x.Cidade).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Usuario>().Property(x => x.Estado).HasMaxLength(2).HasColumnType("varchar(2)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(150).HasColumnType("varchar(150)"); ;
            modelBuilder.Entity<Usuario>().Property(x => x.Regra).HasMaxLength(3).HasColumnType("varchar(3)");
            modelBuilder.Entity<Usuario>().Property(x => x.EmpresaId);
            modelBuilder.Entity<Usuario>().Property(x => x.ClienteId);

            modelBuilder.Entity<Chamado>().ToTable("Chamado");
            modelBuilder.Entity<Chamado>().Property(x => x.Id);
            modelBuilder.Entity<Chamado>().Property(x => x.Texto).HasMaxLength(500).HasColumnType("varchar(500)");
            modelBuilder.Entity<Chamado>().Property(x => x.DataHora);
            modelBuilder.Entity<Chamado>().Property(x => x.UsuarioId);
            modelBuilder.Entity<Chamado>().Property(x => x.EmpresaId);
            modelBuilder.Entity<Chamado>().Property(x => x.ClienteId);
        }
    }
}