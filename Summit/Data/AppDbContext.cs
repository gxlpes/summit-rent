using Microsoft.EntityFrameworkCore;
using Summit.Models;

namespace Summit.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=summit.db;Cache=shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Carro> Carro { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Aluguel> Aluguel { get; set; }

        public DbSet<Seguro> Seguro { get; set; }

        public DbSet<Avaliacao> Avaliacao { get; set; }

        public DbSet<Pagamento> Pagamento { get; set; }

        public DbSet<Tentativa> Tentativa { get; set; }

        public DbSet<Chegada> Chegada { get; set; }

        public DbSet<Saida> Saida { get; set; }

        public DbSet<Concessionaria> Concessionaria { get; set; }

    }
}
