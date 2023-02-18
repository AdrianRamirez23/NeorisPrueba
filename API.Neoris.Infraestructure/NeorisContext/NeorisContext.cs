using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class NeorisContext : DbContext
{
    public NeorisContext()
    {
    }

    public NeorisContext(DbContextOptions<NeorisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TiposCuenta> TiposCuentas { get; set; }

    public virtual DbSet<TiposMovimiento> TiposMovimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.101,1433;Database=Neoris;User ID=sa;Password=Nicolas1*;Trusted_Connection=false;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK_Cliente_1");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.ClienteId, "IX_Cliente_1").IsUnique();

            entity.Property(e => e.ClienteId).ValueGeneratedNever();

            entity.HasOne(d => d.ClienteNavigation).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Persona");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.NumeroCuenta).HasName("PK_Cliente");

            entity.HasIndex(e => e.NumeroCuenta, "IX_Cliente").IsUnique();

            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Cliente");

            entity.HasOne(d => d.TipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.TipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_TiposCuentas");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.Property(e => e.Genero1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Genero");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.ToTable("Movimiento");

            entity.Property(e => e.IdMovimiento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.NumeroCuentaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.NumeroCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimiento_Cuenta");

            entity.HasOne(d => d.TipoMovimientoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.TipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimiento_TiposMovimientos");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("Persona");

            entity.HasIndex(e => e.Identificacion, "IX_Persona").IsUnique();

            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Genero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Generos");
        });

        modelBuilder.Entity<TiposCuenta>(entity =>
        {
            entity.HasKey(e => e.IdTipoCuenta);

            entity.HasIndex(e => e.IdTipoCuenta, "IX_TiposCuentas").IsUnique();

            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento);

            entity.HasIndex(e => e.IdTipoMovimiento, "IX_TiposMovimientos").IsUnique();

            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
