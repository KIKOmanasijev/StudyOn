using Court.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Court.Data
{
    public partial class CourtsDbContext : DbContext
    {
        public CourtsDbContext()
        {
        }

        public CourtsDbContext(DbContextOptions<CourtsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courts> Courts { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<UserMatches> UserMatches { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Courts>(entity =>
            {
                entity.ToTable("courts", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Sport)
                    .HasColumnName("sport")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.ToTable("images", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(64);

                entity.Property(e => e.CourtId)
                    .HasColumnName("courtId")
                    .HasColumnType("numeric");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courtFK");
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.ToTable("matches", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(64);

                entity.Property(e => e.CourtId)
                    .HasColumnName("courtId")
                    .HasColumnType("numeric");

                entity.Property(e => e.CurrentPlayers).HasColumnName("currentPlayers");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("date");

                entity.Property(e => e.MaxPlayers).HasColumnName("maxPlayers");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courtFK");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.ToTable("ratings", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(64);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(256);

                entity.Property(e => e.CourtId)
                    .HasColumnName("courtId")
                    .HasColumnType("numeric");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courtFK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userFK");
            });

            modelBuilder.Entity<UserMatches>(entity =>
            {
                entity.ToTable("userMatches", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(64);

                entity.Property(e => e.MatchId)
                    .IsRequired()
                    .HasColumnName("matchId")
                    .HasMaxLength(64);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.UserMatches)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matchFK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMatches)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userFK");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "my_schema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(64);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(64);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
