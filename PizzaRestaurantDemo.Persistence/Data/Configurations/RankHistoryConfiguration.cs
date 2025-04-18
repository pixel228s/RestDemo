using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Persistence.Data.Configurations
{
    public class RankHistoryConfiguration : IEntityTypeConfiguration<RankHistory>
    {
        public void Configure(EntityTypeBuilder<RankHistory> builder)
        {
            builder.ToTable("feedbacks", "dbo");
            builder.HasKey(x => x.Id);  

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(u => u.User)
                .WithMany(r => r.Ranks)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(p => p.Pizza)
                .WithMany(r => r.Ranks)
                .HasForeignKey(p => p.PizzaId);
            builder.HasQueryFilter(r => !r.IsDeleted);

        }
    }
}
