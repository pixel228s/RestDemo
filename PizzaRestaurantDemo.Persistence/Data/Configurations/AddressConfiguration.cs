using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.ToTable("address", "dbo");

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasOne(u => u.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
