using System;
using System.Collections.Generic;
using Actividad4ApiSegura.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad4ApiSegura.BibliotecaDbContext;

public partial class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autor__3214EC073EF60762");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libros_Autor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
