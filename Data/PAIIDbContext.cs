using Data.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace Data;
 
public class PAIIDbContext : DbContext
{
    public PAIIDbContext(DbContextOptions<PAIIDbContext> context) : base(context)
    {
 
    }
 
    public DbSet<Alumnos> Alumnos { get; set; }
}