using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Application.Images.Interfaces;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure.Implementations.Base;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(PizzaRestaurantDbContext context) : base(context)
        {
        }

        public Task<Image?> GetImageById(int pizzaId, CancellationToken cancellationToken)
        {
            return  _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PizzaId == pizzaId);
        }

        public Task<bool> IsPresent(int pizzaId, CancellationToken cancellationToken)
        {
            return _dbSet
                .AsNoTracking()
                .AnyAsync(x => x.PizzaId == pizzaId, cancellationToken);
        }
    }
}
