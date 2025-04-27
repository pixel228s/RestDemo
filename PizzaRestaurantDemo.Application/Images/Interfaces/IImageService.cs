using Microsoft.AspNetCore.Http;

namespace PizzaRestaurantDemo.Application.Images.Interfaces
{
    public interface IImageService
    {
        Task<string> Get(int pizzaId, CancellationToken cancellationToken);
        Task<Tuple<string, string>> SaveImage(IFormFile file);
        Task UploadImage(IFormFile formFile, int pizzaId, CancellationToken cancellationToken);
    }
}
