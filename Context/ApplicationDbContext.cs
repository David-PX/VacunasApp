using VacunasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VacunasApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Personas> personas { get; set; }
        public DbSet<Vacunas> vacunas { get; set; }
        public DbSet<Provincias> provincias { get; set; }
        public DbSet<Pais> pais { get; set; }
        public DbSet<SignosSodiacales> signossodiacales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>(persona => {

                persona.HasOne(p => p.PrimeraDosis)
                .WithMany()
                .HasForeignKey(p => p.primeradosis_id)
                .HasConstraintName("persona_primeradosis_id_fkey");

                persona.HasOne(p => p.SegundaDosis)
                .WithMany()
                .HasForeignKey(p => p.segundadosis_id)
                .HasConstraintName("persona_segundadosis_id_fkey");

                persona.HasOne(p => p.Provincias)
                .WithMany()
                .HasForeignKey(p => p.provincia_id)
                .HasConstraintName("persona_provincia_id_fkey");

                persona.HasOne(p => p.SignosSodiacales)
                .WithMany()
                .HasForeignKey(p => p.signosodiacal_id)
                .HasConstraintName("persona_signosodiacal_id_id_fkey");

            });

            modelBuilder.Entity<Provincias>(provincia => {

                provincia.HasOne(p => p.Pais)
                .WithMany()
                .HasForeignKey(p => p.pais_id)
                .HasConstraintName("provincias_pais_id_fkey");

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
