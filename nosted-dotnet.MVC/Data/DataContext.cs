using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ansatt>().HasKey(x => x.Id);
        modelBuilder.Entity<Vinsj>().HasKey(x => x.Id);
        modelBuilder.Entity<Kunde>().HasKey(x => x.Id);
        modelBuilder.Entity<Adresse>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Entites.Ordre>().HasKey(x => x.Id);
        modelBuilder.Entity<ServiceSkjema>().HasKey(x => x.Id);
        modelBuilder.Entity<Sjekkliste>().HasKey(x => x.Id);
        modelBuilder.Entity<Sjekk>().HasKey(x => x.Id);
        modelBuilder.Entity<UtførtSjekk>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Vinsj>()
            .HasOne(v => v.Kunde)
            .WithOne(k => k.Vinsj)
            .HasForeignKey<Kunde>(k => k.VinsjId);
        modelBuilder.Entity<Kunde>()
            .HasOne(k => k.Ordre)
            .WithOne(o => o.Kunde)
            .HasForeignKey<Entites.Ordre>(o => o.KundeId);
        
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
    
    public required DbSet<Vinsj> Vinsj { get; set; }
    public required DbSet<Ansatt> Ansatt { get; set; }
    public required DbSet<Kunde> Kunde { get; set; }
    public required DbSet<Adresse> Adresse { get; set; }
    
    public required DbSet<Entites.Ordre> Ordre { get; set; }
    public required DbSet<ServiceSkjema> ServiceSkjema { get; set; }
    public required DbSet<Sjekkliste> Sjekkliste { get; set; }
    public required DbSet<Sjekk> Sjekk { get; set; }
    public required DbSet<UtførtSjekk> UtførtSjekk { get; set; }
}