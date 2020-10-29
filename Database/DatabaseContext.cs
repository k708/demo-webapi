using demo_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace demo_webapi.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
         {
             _configuration = configuration;
         }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>().ToTable("T_FRUIT");
        }
        
        public DbSet<Fruit> Fruits { get; set; }
    }
}