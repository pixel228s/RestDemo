using Microsoft.AspNetCore.Http;

namespace PizzaRestaurantDemo.Application.Images.Interfaces
{
    public interface IImageService
    {
        Task DeleteImage(int pizzaId, CancellationToken cancellationToken);
        Task UpdateImage(int pizzaId, CancellationToken cancellationToken);
        Task UploadImage(IFormFile formFile, CancellationToken cancellationToken);
    }
}
