using Entities.Entities;
using Entities.Notification;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaFornecedor> EmpresaFornecedor { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Cep> Cep { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao(),
                    options => options.EnableRetryOnFailure());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.RG)
                .HasConversion(
                v => v ?? "", // Converte null para uma string vazia
                v => v
        );

            modelBuilder.Entity<EmpresaFornecedor>()
                .HasKey(ef => new { ef.EmpresaID, ef.FornecedorID });

            modelBuilder.Entity<EmpresaFornecedor>()
                .HasOne(ef => ef.Empresa)
                .WithMany(e => e.Fornecedores)
                .HasForeignKey(ef => ef.EmpresaID)
                .OnDelete(DeleteBehavior.Restrict); // Defina a ação para 'NoAction'

            modelBuilder.Entity<EmpresaFornecedor>()
                .HasOne(ef => ef.Fornecedor)
                .WithMany(f => f.Empresas)
                .HasForeignKey(ef => ef.FornecedorID)
                .OnDelete(DeleteBehavior.Restrict); // Defina a ação para 'NoAction'

            modelBuilder.Entity<Cep>(entity =>
            {
                // ...
                entity.Property(e => e.EmpresaId).IsRequired(false); // Permite nulos
                entity.Property(e => e.FornecedorId).IsRequired(false); // Permite nulos
            });

            base.OnModelCreating(modelBuilder);
        }


        public string ObterStringConexao()
        {
            string strcon = "Data Source=DESKTOP-9JQQ5ER\\SQLSERVER2022;Initial Catalog=Accenture;Integrated Security=False;User ID=DavidDev;Password=Dev123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strcon;
        }
    }
}
