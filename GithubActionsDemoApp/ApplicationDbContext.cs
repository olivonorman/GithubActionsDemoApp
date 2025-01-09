using GithubActionsDemoApp.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GithubActionsDemoApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
