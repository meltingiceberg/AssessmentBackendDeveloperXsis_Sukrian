using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssessmentBackendDeveloperXsis_Sukrian.Entities;

public partial class MoviesdbContext : DbContext
{
    public MoviesdbContext()
    {
    }

    public MoviesdbContext(DbContextOptions<MoviesdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movie");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Rating).HasDefaultValueSql("'0'");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
