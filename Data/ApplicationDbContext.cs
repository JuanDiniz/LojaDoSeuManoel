using Microsoft.EntityFrameworkCore;
using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .OwnsOne(p => p.Dimensoes);

            base.OnModelCreating(modelBuilder);
        }
    }
}