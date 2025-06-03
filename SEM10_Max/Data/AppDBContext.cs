using Microsoft.EntityFrameworkCore;
using SEM10_Max.Models;
namespace SEM10_Max.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { 
        
        }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empleado>(tb =>
            { 
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Apellido).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleados");
        }
    }
}
