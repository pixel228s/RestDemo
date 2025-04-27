using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure;

namespace PizzaRestaurantDemo.Application.Images.Interfaces
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<Image?> GetImageById(int pizzaId, CancellationToken cancellationToken);
        Task<bool> IsPresent(int pizzaId, CancellationToken cancellationToken);
    }
}
