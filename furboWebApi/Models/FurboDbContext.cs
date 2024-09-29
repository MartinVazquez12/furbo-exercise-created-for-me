using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace furboWebApi.Models;

public partial class FurboDbContext : DbContext
{
    public FurboDbContext()
    {
    }

    public FurboDbContext(DbContextOptions<FurboDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clube> Clubes { get; set; }

    public virtual DbSet<Jugador> Jugadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=furboDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clube>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Club).HasMaxLength(100);
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.ToTable("Jugador");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Edad).HasMaxLength(50);
            entity.Property(e => e.IdClub).HasColumnName("Id_Club");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Posicion).HasMaxLength(50);
            entity.Property(e => e.ValorMercado)
                .HasMaxLength(50)
                .HasColumnName("Valor_Mercado");

            entity.HasOne(d => d.IdClubNavigation).WithMany(p => p.Jugadors)
                .HasForeignKey(d => d.IdClub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jugador_Clubes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
