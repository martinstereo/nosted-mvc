using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace nosted_dotnet.MVC.Entities
{
    public class NostedDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public NostedDbContext()
        {
            
        }
        public NostedDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public NostedDbContext(DbContextOptions<NostedDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        // Define DbSet properties for your entities
        public DbSet<User> Users { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<ServiceSchema> ServiceSchemas { get; set; }
        public DbSet<ChecklistCategory> ChecklistCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerInformation> CustomerInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, constraints, and indexes here

            modelBuilder.Entity<CheckList>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CheckList>()
                .HasOne(e => e.ServiceSchema)
                .WithOne(e => e.CheckList)
                .HasForeignKey<ServiceSchema>(e => e.Id);

            modelBuilder.Entity<ServiceSchema>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<ServiceSchema>()
                .HasOne(e => e.Order)
                .WithOne(e => e.ServiceSchema)
                .HasForeignKey<Order>(e => e.Id);

            modelBuilder.Entity<ServiceSchema>()
                .HasOne(e => e.CheckList)
                .WithOne(e => e.ServiceSchema)
                .HasForeignKey<CheckList>(e => e.Id);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.ServiceSchema)
                .WithOne(e => e.Order)
                .HasForeignKey<ServiceSchema>(e => e.Id);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.CustomerInformation)
                .WithOne(e => e.Order)
                .HasForeignKey<CustomerInformation>(e => e.Id);

            modelBuilder.Entity<Order>()
                .HasOne( e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CustomerInformation>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.Id);

            modelBuilder.Entity<CustomerInformation>()
                .HasOne(e => e.Order)
                .WithOne(e => e.CustomerInformation)
                .HasForeignKey<Order>(e => e.Id);


        }
    }
}