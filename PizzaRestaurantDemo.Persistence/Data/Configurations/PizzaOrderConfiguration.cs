using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class PizzaOrderConfiguration : IEntityTypeConfiguration<PizzaOrder>
    {
        public void Configure(EntityTypeBuilder<PizzaOrder> builder)
        {
            builder.ToTable("pizzaOrders", "dbo");

            builder.HasKey(op => new { op.OrderId, op.PizzaId });

            builder.HasOne(p => p.Pizza)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.PizzaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Order)
                .WithMany(o => o.Pizzas)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
