using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Data.Models;

namespace ProyectoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Edificio> Edificio { get; set; }
        public DbSet<Instalacion> Instalacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la clave primaria para la entidad Carrera
            modelBuilder.Entity<Carrera>().HasKey(c => c.IDCarrera); // Usando Id para seguir la convención de nombres

            // Configura la relación uno a muchos entre Carrera y Profesor
            modelBuilder.Entity<Carrera>()
                .HasMany(c => c.Profesores)
                .WithOne(p => p.Carrera)
                .HasForeignKey(p => p.CarreraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Edificio>()
                .HasMany(e => e.Instalaciones)
                .WithOne(i => i.edificio)
                .HasForeignKey(i => i.EdificioID)
                .OnDelete(DeleteBehavior.Restrict);
        }



    }
}
