using Microsoft.EntityFrameworkCore;

namespace nosted_dotnet.MVC.Entities
{
    public class NostedDbContext : DbContext
    {
        public NostedDbContext(DbContextOptions<NostedDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sqlite database
        //    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

        //}

        // Define DbSet properties for your entities
        public DbSet<User> Users { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<ServiceSchema> ServiceSchemas { get; set; }
        public DbSet<ChecklistCategory> ChecklistCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerInformation> CustomerInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.CustomerInformation)
                .WithOne(e => e.Order)
                .HasForeignKey<CustomerInformation>(e => e.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.ServiceSchema)
                .WithOne(e => e.Order)
                .HasForeignKey<ServiceSchema>(e => e.OrderId);

            modelBuilder.Entity<ServiceSchema>()
                .HasOne(e => e.CheckList)
                .WithOne(e => e.ServiceSchema)
                .HasForeignKey<CheckList>(e => e.ServiceSchemaId);

            // this entitiy configuration has already covered by ef core, so that's why is disabled
            //modelBuilder.Entity<CheckList>()
            //    .HasMany(e => e.ChecklistCategories)
            //    .WithOne()
            //    .HasForeignKey(e => e.CheckListId);
        }
    }
}