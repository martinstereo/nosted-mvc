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
        
        modelBuilder.Entity<UserEntity>().ToTable("Users").HasKey(x => x.Id);
        modelBuilder.Entity<Adresse>().ToTable("Adresse").HasKey(x => x.Id);
        modelBuilder.Entity<Kunde>().ToTable("Kunde").HasKey(x => x.Id);
        modelBuilder.Entity<Produkt>().ToTable("Produkt").HasKey(x => x.Id);
        
        modelBuilder.Entity<Ordre>().ToTable("Ordre").HasKey(x => x.Id);
        modelBuilder.Entity<Sjekkliste>().ToTable("Sjekkliste").HasKey(x => x.Id);
        modelBuilder.Entity<Entities.ServiceSkjema>().ToTable("ServiceSkjema").HasKey(x => x.Id);
        
        modelBuilder.Entity<Kunde>()
            .HasOne(k => k.Adresse)
            .WithMany()
            .HasForeignKey(k => k.AdresseId);
        
        modelBuilder.Entity<Ordre>()
            .HasOne(o => o.Produkt)
            .WithMany()
            .HasForeignKey(o => o.ProduktId);
        
        modelBuilder.Entity<Entities.ServiceSkjema>()
            .HasOne(o => o.Ordre)
            .WithMany()
            .HasForeignKey(o => o.OrdreId);
        
        modelBuilder.Entity<Sjekkliste>()
            .HasOne(o => o.Ordre)
            .WithMany()
            .HasForeignKey(o => o.OrdreId);
        
            base.OnModelCreating(modelBuilder);
        }

        public required DbSet<Produkt> Produkt { get; set; }
        public required DbSet<UserEntity> Users { get; set; }
        public required DbSet<Kunde> Kunde { get; set; }
        public required DbSet<Adresse> Adresse { get; set; }

        public required DbSet<Ordre> Ordre { get; set; }
        public required DbSet<Entities.ServiceSkjema> ServiceSkjema { get; set; }
        public required DbSet<Sjekkliste> Sjekkliste { get; set; }
    }
}