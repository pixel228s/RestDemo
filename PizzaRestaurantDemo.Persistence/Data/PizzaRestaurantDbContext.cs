using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaRestaurantDemo.Domain.Base;
using PizzaRestaurantDemo.Domain.Models;
using System.Data;

namespace PizzaRestaurantDemo.Persistence.Data
{
    public class PizzaRestaurantDbContext : DbContext
    {
        public PizzaRestaurantDbContext(DbContextOptions<PizzaRestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<User> users {  get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Address> Addresses { get; set; }  
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<RankHistory> RankHistory { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaRestaurantDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.EntityPreparations();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void EntityPreparations()
        {
            var entities = ChangeTracker
                .Entries<BaseEntity>()
                .Where(c => c.State == EntityState.Modified || c.State == EntityState.Added);

            foreach (EntityEntry<BaseEntity> entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedOn = DateTime.UtcNow;
                }

                entity.Entity.UpdatedOn = DateTime.UtcNow;
            }
        }
    }
}
