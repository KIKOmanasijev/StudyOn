﻿using Microsoft.EntityFrameworkCore;
using StudyOn.Contracts.Models;

namespace StudyOn.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Courts> Courts { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Users> Users { get; set; }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.HasPostgresExtension("adminpack");

        //        modelBuilder.Entity<Courts>(entity =>
        //        {
        //            entity.ToTable("courts", "my_schema");

        //            entity.Property(e => e.Id)
        //                .HasColumnName("id")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Lat).HasColumnName("lat");

        //            entity.Property(e => e.Lng).HasColumnName("lng");

        //            entity.Property(e => e.Name)
        //                .HasColumnName("name")
        //                .HasMaxLength(20);

        //            entity.Property(e => e.Sport)
        //                .HasColumnName("sport")
        //                .HasMaxLength(20);
        //        });

        //        modelBuilder.Entity<Images>(entity =>
        //        {
        //            entity.ToTable("images", "my_schema");

        //            entity.Property(e => e.Id)
        //                .HasColumnName("id")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.CourtId)
        //                .HasColumnName("courtId")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.ImagePath)
        //                .IsRequired()
        //                .HasColumnName("imagePath")
        //                .HasColumnType("character varying");

        //            entity.HasOne(d => d.Court)
        //                .WithMany(p => p.Images)
        //                .HasForeignKey(d => d.CourtId)
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("images_courtId_fkey1");
        //        });

        //        modelBuilder.Entity<Matches>(entity =>
        //        {
        //            entity.ToTable("matches", "my_schema");

        //            entity.Property(e => e.Id)
        //                .HasColumnName("id")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.CourtId)
        //                .HasColumnName("courtId")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Date)
        //                .HasColumnName("date")
        //                .HasColumnType("date");

        //            entity.Property(e => e.MaxPlayers)
        //                .HasColumnName("maxPlayers")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Time)
        //                .HasColumnName("time")
        //                .HasColumnType("time without time zone");

        //            entity.Property(e => e.UserId)
        //                .HasColumnName("userId")
        //                .HasColumnType("numeric");

        //            entity.HasOne(d => d.Court)
        //                .WithMany(p => p.Matches)
        //                .HasForeignKey(d => d.CourtId)
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("matches_courtId_fkey");

        //            entity.HasOne(d => d.User)
        //                .WithMany(p => p.Matches)
        //                .HasForeignKey(d => d.UserId)
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("matches_userId_fkey");
        //        });

        //        modelBuilder.Entity<Ratings>(entity =>
        //        {
        //            entity.ToTable("ratings", "my_schema");

        //            entity.Property(e => e.Id)
        //                .HasColumnName("id")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Comment)
        //                .HasColumnName("comment")
        //                .HasColumnType("character varying");

        //            entity.Property(e => e.CourtId)
        //                .HasColumnName("courtId")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.UserId)
        //                .HasColumnName("userId")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Value)
        //                .HasColumnName("value")
        //                .HasColumnType("numeric");

        //            entity.HasOne(d => d.Court)
        //                .WithMany(p => p.Ratings)
        //                .HasForeignKey(d => d.CourtId)
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("images_courtId_fkey");

        //            entity.HasOne(d => d.User)
        //                .WithMany(p => p.Ratings)
        //                .HasForeignKey(d => d.UserId)
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("images_userId_fkey");
        //        });

        //        modelBuilder.Entity<Users>(entity =>
        //        {
        //            entity.ToTable("users", "my_schema");

        //            entity.Property(e => e.Id)
        //                .HasColumnName("id")
        //                .HasColumnType("numeric");

        //            entity.Property(e => e.Email)
        //                .IsRequired()
        //                .HasColumnName("email")
        //                .HasColumnType("character varying");

        //            entity.Property(e => e.FirstName)
        //                .IsRequired()
        //                .HasColumnName("firstName")
        //                .HasColumnType("character varying");

        //            entity.Property(e => e.LastName)
        //                .IsRequired()
        //                .HasColumnName("lastName")
        //                .HasColumnType("character varying");

        //            entity.Property(e => e.Password)
        //                .IsRequired()
        //                .HasColumnName("password")
        //                .HasColumnType("character varying");

        //            entity.Property(e => e.Role)
        //                .IsRequired()
        //                .HasColumnName("role")
        //                .HasColumnType("character varying");
        //        });

        //        OnModelCreatingPartial(modelBuilder);
        //    }

        //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        //}
    }
}

