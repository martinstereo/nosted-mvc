using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Entites;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceSkjema>().HasKey(x => x.Id);
            modelBuilder.Entity<Sjekkliste>().HasKey(x => x.Id);
            modelBuilder.Entity<Sjekk>().HasKey(x => x.Id);
            modelBuilder.Entity<UtførtSjekk>().HasKey(x => x.Id);
        
            modelBuilder.Entity<UserEntity>().ToTable("Users").HasKey(x => x.Id);
            modelBuilder.Entity<Adresse>().ToTable("Adresse").HasKey(x => x.Id);
            modelBuilder.Entity<Kunde>().ToTable("Kunde").HasKey(x => x.Id);
            modelBuilder.Entity<Produkt>().ToTable("Produkt").HasKey(x => x.Id);
            modelBuilder.Entity<Ordre>().ToTable("Ordre").HasKey(x => x.Id);
            
            modelBuilder.Entity<Kunde>()
                .HasOne(k => k.Adresse)
                .WithMany()
                .HasForeignKey(k => k.AdresseId);

            modelBuilder.Entity<Ordre>()
                .HasOne(o => o.Kunde)
                .WithMany()
                .HasForeignKey(o => o.KundeId);

            modelBuilder.Entity<Ordre>()
                .HasOne(o => o.Produkt)
                .WithMany()
                .HasForeignKey(o => o.ProduktId);
        
            /*modelBuilder.Entity<Entites.Ordre>()
                .HasOne(o => o.Sjekkliste)
                .WithOne(s => s.Ordre)
                .HasForeignKey<Sjekkliste>(s => s.OrdreId);
            modelBuilder.Entity<Entites.Ordre>()
                .HasOne(o => o.ServiceSkjema)
                .WithOne(s => s.Ordre)
                .HasForeignKey<ServiceSkjema>(s => s.OrdreId);*/
        
            modelBuilder.Entity<UtførtSjekk>()
                .HasOne<Sjekkliste>(s => s.Sjekkliste)
                .WithMany(sl => sl.UtførteSjekker);
            modelBuilder.Entity<UtførtSjekk>()
                .HasOne<Sjekk>(s => s.Sjekk)
                .WithMany(sl => sl.UtførteSjekker);
        
            base.OnModelCreating(modelBuilder);
        }
    
        public required DbSet<Produkt> Produkt { get; set; }
        public required DbSet<UserEntity> Users { get; set; }
        public required DbSet<Kunde> Kunde { get; set; }
        public required DbSet<Adresse> Adresse { get; set; }
        public required DbSet<Ordre> Ordre { get; set; }
        public required DbSet<ServiceSkjema> ServiceSkjema { get; set; }
        public required DbSet<Sjekkliste> Sjekkliste { get; set; }
        public required DbSet<Sjekk> Sjekk { get; set; }
        public required DbSet<UtførtSjekk> UtførtSjekk { get; set; }
    }
}