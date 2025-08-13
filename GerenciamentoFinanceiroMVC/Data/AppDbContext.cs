using GerenciamentoFinanceiroMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiroMVC.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Financeiro> Financas {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = "educacao", NomeCategoria = "Educação" },
                new Categoria { CategoriaId = "salario", NomeCategoria = "Salário" },
                new Categoria { CategoriaId = "viagem", NomeCategoria = "Viagem" },
                new Categoria { CategoriaId = "mercado", NomeCategoria = "Mercado" },
                new Categoria { CategoriaId = "comissao", NomeCategoria= "Comissão" }
                );



            modelBuilder.Entity<Transacao>().HasData(
            new Transacao { TransacaoId = "ganho", NomeTransacao = "Ganho" },
            new Transacao { TransacaoId = "gasto", NomeTransacao = "Gasto" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
