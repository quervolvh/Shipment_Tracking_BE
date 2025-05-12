using Microsoft.EntityFrameworkCore;

namespace shipment_track.src.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSet Section
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Carrier> Carriers { get; set; }

        #endregion

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        //     ApplicationDbContextConfigurations.Configure(builder);
        // }

    }
}