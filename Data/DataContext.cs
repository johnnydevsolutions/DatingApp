using DatingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<AppUser>()
        .Property(x => x.Birthday)
        .HasColumnType("date");
    }

    }
}