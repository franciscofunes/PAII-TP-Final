using Data.Converters;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PAIIDbContext : DbContext
{
    public PAIIDbContext(DbContextOptions<PAIIDbContext> context) : base(context)
    {

    }

    public DbSet<Alumnos> Alumnos { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumnos>()
            .Property(a => a.Promedio)
            .HasColumnType("decimal(5, 2)");

              modelBuilder
        .Entity<Inscripcion>()
        .Property(e => e.Estado)
        .HasConversion(new EstadoInscripcionConverter());

        base.OnModelCreating(modelBuilder);
    }
}
