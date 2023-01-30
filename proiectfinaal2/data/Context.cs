using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proiectfinaal2.Entities;
using proiectfinaal2.Models.entities;
using proiectfinaal2.Models.entities2;

namespace proiectfinaal2.data
{
    public class Context : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<SessionToken> SessionTokens { get; set; }
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

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });
        }
    }
}
