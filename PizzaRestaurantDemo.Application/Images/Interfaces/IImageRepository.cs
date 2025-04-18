using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Application.Images.Interfaces
{
    public interface IImageRepository
    {
        Task<Image?> GetImageById(int pizzaId, CancellationToken cancellationToken);
    }
}
