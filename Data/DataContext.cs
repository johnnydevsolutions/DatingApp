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
        .Property(e => e.DateOfBirth)
                .HasConversion(
                    v => new DateTime(v.Year, v.Month, v.Day), // Convert DateOnly to DateTime
                    v => DateOnly.FromDateTime(v.Date));       // Convert DateTime to DateOnly
        }
    }
}