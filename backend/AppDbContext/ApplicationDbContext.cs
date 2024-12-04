using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Raca> Raca { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("pg"));
        }
    }
}
