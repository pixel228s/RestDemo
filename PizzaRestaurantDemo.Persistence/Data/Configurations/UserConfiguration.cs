using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasColumnType("nvarchar(25)");
            builder.Property(u => u.LastName).HasColumnType("nvarchar(35)");

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired();

            builder.Property(u => u.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(u => !u.IsDeleted);

            //builder
            //    .HasOne(u => u.Address)
            //    .WithOne(a => a.User)
            //    .HasForeignKey<User>(u => u.AddressId);
        }
    }
}
