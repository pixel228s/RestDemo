using Microsoft.AspNetCore.Http;
using PizzaRestaurantDemo.Application.Images.Interfaces;

namespace PizzaRestaurantDemo.Application.Images
{
    public class ImageService : IImageService
    {
        public Task DeleteImage(int pizzaId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateImage(int pizzaId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(IFormFile formFile, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
