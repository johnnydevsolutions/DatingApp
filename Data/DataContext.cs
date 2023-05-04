using back.Entities;
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
        public DbSet<UserLike> Likes { get; set; }

        /* protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<AppUser>()
        .Property(e => e.DateOfBirth)
                .HasConversion(
                    v => new DateTime(v.Year, v.Month, v.Day), // Convert DateOnly to DateTime
                    v => DateOnly.FromDateTime(v.Date));       // Convert DateTime to DateOnly
        }
    } */

     protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração para UserLike
            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuração para DateOfBirth
            builder.Entity<AppUser>()
                .Property(e => e.DateOfBirth)
                .HasConversion(
                    v => new DateTime(v.Year, v.Month, v.Day), // Convert DateOnly to DateTime
                    v => DateOnly.FromDateTime(v.Date));       // Convert DateTime to DateOnly
        }
    }
}
