using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Shared.Models;
using PizzaRestaurantDemo.Shared.Services;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICloudService _cloudService;
        private readonly IConfiguration _config;
        public TestController(ICloudService cloudService, IConfiguration config)
        {
            this._cloudService = cloudService;
            this._config = config;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            return null;
        }
    }
}
