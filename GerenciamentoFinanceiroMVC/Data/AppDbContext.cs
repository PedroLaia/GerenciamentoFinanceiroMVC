using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiroMVC.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


    }
}
