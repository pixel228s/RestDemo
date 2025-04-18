using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizza", "dbo"); 
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(25)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.CaloryCount).IsRequired();

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
                
            builder.HasQueryFilter(pizza => !pizza.IsDeleted);
        }
    }
}
