using Microsoft.EntityFrameworkCore;
using Database.Entities;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        public DbSet<Series> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            #region Tables
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Series>().HasKey(s => s.Id);
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            modelBuilder.Entity<Producer>().HasKey(p => p.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Series>()
                .HasOne(s => s.PrimaryGenre)
                .WithMany()
                .HasForeignKey(s => s.PrimaryGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Series>()
                .HasOne(s => s.SecondaryGenre)
                .WithMany()
                .HasForeignKey(s => s.SecondaryGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Series>()
                .HasOne(s => s.Producer)
                .WithMany()
                .HasForeignKey(s => s.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Properties Configuration

            #region Series
            modelBuilder.Entity<Series>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Series>()
                .Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder.Entity<Series>()
                .Property(s => s.ImageLink)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Series>()
                .Property(s => s.VideoLink)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Series>()
                .Property(s => s.ProducerId)
                .IsRequired();

            modelBuilder.Entity<Series>()
                .Property(s => s.PrimaryGenreId)
                .IsRequired();

            modelBuilder.Entity<Series>()
                .Property(s => s.SecondaryGenreId)
                .IsRequired(false);
            #endregion

            #region Genre
            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Genre>()
                .Property(g => g.ImageLink)
                .HasMaxLength(500);
            #endregion

            #region Producer
            modelBuilder.Entity<Producer>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Producer>()
                .Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Producer>()
                .Property(p=> p.ImageLink)
                .HasMaxLength (500);
            #endregion

            #endregion
        }
    }
}
