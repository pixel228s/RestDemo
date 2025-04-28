using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Images.Interfaces;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("pizza-image/{pizzaId}")]
        public async Task<IActionResult> GetImage(int pizzaId, CancellationToken cancellationToken)
        {
            var result = await _imageService.Get(pizzaId, cancellationToken);
            return Ok(new
            {
                path = result
            });
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile image, int pizzaId, CancellationToken cancellationToken)
        {
            await _imageService.UploadImage(image, pizzaId, cancellationToken);
            return Ok();
        }
    }
}
