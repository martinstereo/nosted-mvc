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
        }
    }
}