using Data.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace Data;
 
public class PAIIDbContext : DbContext
{
    public PAIIDbContext(DbContextOptions<PAIIDbContext> context) : base(context)
    {
 
    }

    public DbSet<Alumnos> Alumnos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumnos>()
            .Property(a => a.Promedio)
            .HasColumnType("decimal(5, 2)"); // Specify the SQL Server column type here

        base.OnModelCreating(modelBuilder);
    }
}
