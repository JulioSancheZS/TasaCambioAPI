using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TasaCambioAPI.Models;

public partial class TasaCambioDbContext : DbContext
{
    public TasaCambioDbContext()
    {
    }

    public TasaCambioDbContext(DbContextOptions<TasaCambioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TasaCambio> TasaCambios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DEVCUMPDELL;Database=TasaCambioDB;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasaCambio>(entity =>
        {
            entity.HasKey(e => e.IdTasaCambio);

            entity.ToTable("TasaCambio");

            entity.Property(e => e.IdTasaCambio).ValueGeneratedNever();
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
