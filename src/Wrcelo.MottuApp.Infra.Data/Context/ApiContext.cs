using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Infra.Data.Mappings;

namespace Wrcelo.VrumApp.Infra.Data.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MotorcycleMap());
            modelBuilder.ApplyConfiguration(new DeliveryDriverMap());
            modelBuilder.ApplyConfiguration(new RentalMap());


        }
    }
}
