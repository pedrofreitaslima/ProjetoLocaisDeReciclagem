using Microsoft.EntityFrameworkCore;
using ProjetoLocaisDeReciclagem.Data.Maps;
using ProjetoLocaisDeReciclagem.Models;

namespace ProjetoLocaisDeReciclagem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<LocaisReciclagem> LocaisReciclagem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=projetolocaisreciclagem;User ID=sa;Password=Code@2021");
            //a linha acima configura os dados para acessar o SQL Server
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocaisReciclagemMap());
        }

    }
}