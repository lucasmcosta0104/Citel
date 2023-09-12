global using Microsoft.EntityFrameworkCore;
using Citel.Application.Models;

namespace Citel.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasOne(x => x.Categoria)
                .WithMany(x => x.Produto)
                .HasForeignKey(x => x.CategoriaId);
            });
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
