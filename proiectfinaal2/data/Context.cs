using Microsoft.EntityFrameworkCore;
using proiectfinaal2.Entities;

namespace proiectfinaal2.data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Stapan> Stapani { get; set; }
        public DbSet<Medicament> Medicamente { get; set; }
        public DbSet<AnimalMedicament> AnimalMedicamente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Animal>()
                .HasMany(a => a.Stapani)
                .WithOne(s => s.Animal);
            //.OnDelete(DeleteBehavior.NoAction);
/*       
            builder.Entity<Stapan>()
                .HasOne(s => s.Address)
                .WithOne(adr => adr.Stapan);
            //.OnDelete(DeleteBehavior.NoAction);
*/
            builder.Entity<Animal>()
                 .HasOne(a => a.Address) 
                 .WithOne(adr => adr.Animal);
            //.OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AnimalMedicament>().HasKey(am => new { am.MedicamentId, am.AnimalId });

            builder.Entity<AnimalMedicament>()
                .HasOne(am => am.Animal)
                .WithMany(a => a.AnimalMedicamente)
                .HasForeignKey(am => am.AnimalId);

            builder.Entity<AnimalMedicament>()
                .HasOne(am => am.Medicament)
                .WithMany(a => a.AnimalMedicamente)
                .HasForeignKey(am => am.MedicamentId);
        }
    }
}
