using WebApi_LivroseAutores;
using Microsoft.EntityFrameworkCore;

namespace WebApi_LivroseAutores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets para as tabelas de Autores e Livros
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }


    }
}
