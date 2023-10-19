using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AppDbContext : DbContext
    {
        public DbSet<Failure> Failures { get; set; }
        public DbSet<Recovery> Recoveries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
