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
    }
}