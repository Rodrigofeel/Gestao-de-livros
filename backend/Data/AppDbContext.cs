using Microsoft.EntityFrameworkCore;
using GestaoDeLivros.models;

namespace GestaoDeLivros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Override do método OnModelCreating para configurar o modelo
        {
            modelBuilder.Entity<Livro>(entity => 
            {
                entity.HasIndex(e => e.ISBN) 
                      .IsUnique();

                entity.HasIndex(e => e.Titulo);

                entity.HasIndex(e => e.Categoria);
                
                entity.HasIndex(e => e.Autor);

                entity.Property(e => e.Titulo)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Categoria)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Autor)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Editora)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.ISBN)
                      .HasMaxLength(17)
                      .IsRequired();

                entity.Property(e => e.Resumo)
                      .HasMaxLength(1000);
            });
        }
    }
}