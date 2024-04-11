using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaseZV.Models;

public partial class CaseZvzvzvzvContext : DbContext
{
    public CaseZvzvzvzvContext()
    {
    }

    public CaseZvzvzvzvContext(DbContextOptions<CaseZvzvzvzvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<Gun> Guns { get; set; }

    public virtual DbSet<GunsOfCase> GunsOfCases { get; set; }

    public virtual DbSet<Inventory> Inventorys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;uid=root;Database=CaseZVZVZVZV");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("balances", "CaseZVZVZVZV");

            entity.HasIndex(e => e.UserId, "user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sum).HasColumnName("sum");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Balances)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id");
        });

        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cases", "CaseZVZVZVZV");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Img)
                .HasMaxLength(45)
                .HasColumnName("img");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Gun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("guns", "CaseZVZVZVZV");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Img)
                .HasMaxLength(45)
                .HasColumnName("img");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<GunsOfCase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("guns_of_case", "CaseZVZVZVZV");

            entity.HasIndex(e => e.Cases, "cases_idx");

            entity.HasIndex(e => e.Gun, "gun_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cases).HasColumnName("cases");
            entity.Property(e => e.Chance).HasColumnName("chance");
            entity.Property(e => e.Gun).HasColumnName("gun");

            entity.HasOne(d => d.CasesNavigation).WithMany(p => p.GunsOfCases)
                .HasForeignKey(d => d.Cases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cases");

            entity.HasOne(d => d.GunNavigation).WithMany(p => p.GunsOfCases)
                .HasForeignKey(d => d.Gun)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gun");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventorys", "CaseZVZVZVZV");

            entity.HasIndex(e => e.GunOfCase, "fk_inventorys_guns_of_case1_idx");

            entity.HasIndex(e => e.User, "user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GunOfCase).HasColumnName("gun_of_case");
            entity.Property(e => e.User).HasColumnName("user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users", "CaseZVZVZVZV");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
