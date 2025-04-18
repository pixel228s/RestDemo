using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("images", "dbo");

            builder.HasKey(x => x.Id);

            builder.HasOne(image => image.Pizza)
                .WithOne(pizza => pizza.Image)
                .HasForeignKey<Image>(image => image.PizzaId);

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.HasQueryFilter(pizza => !pizza.IsDeleted);
        }
    }
}
