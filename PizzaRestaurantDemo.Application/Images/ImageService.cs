using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PizzaRestaurantDemo.Application.Images.Interfaces;
using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Shared.Models;
using PizzaRestaurantDemo.Shared.Services;

namespace PizzaRestaurantDemo.Application.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IConfiguration _config;
        private readonly ICloudService _cloudService;

        public ImageService(
            IImageRepository imageRepository,
            IConfiguration config, 
            ICloudService cloudService)
        {
            _imageRepository = imageRepository;
            _config = config;
            _cloudService = cloudService;
        }

        public async Task<string> Get(int pizzaId, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetImageById(pizzaId, cancellationToken);

            if(image == null)
            {
                return "No image";
            }

            return image.Path;
        }

        public async Task<Tuple<string, string>> SaveImage(IFormFile file)
        {
            await using var memoryStr = new MemoryStream();
            await file.CopyToAsync(memoryStr);

            var fileExtension = Path.GetExtension(file.FileName);
            Console.WriteLine("Extension " + fileExtension);
            if(!(new String[] {".jpg", ".png", ".jpeg" }.Contains(fileExtension)))
            {
                throw new ImageFormatNotAllowedException();
            }
            var objName = $"{Guid.NewGuid().ToString()}{fileExtension}";

            var s3Obj = new S3ObjectMod()
            {
                BucketName = _config["AWSConfigs:AWSBucketName"],
                InputStream = memoryStr,
                Name = objName,
            };

            var creds = new AWSCredentialsCustom()
            {
                AwsKey = _config["AWSConfigs:AWSAccessKey"],
                AwsSecretKey = _config["AWSConfigs:AWSSecretKey"]
            };

            await _cloudService.UploadFileAsync(s3Obj, creds);

            return new Tuple<string, string>(_config["AWSConfigs:Location"] + objName, file.FileName);
        }

        public async Task UploadImage(IFormFile formFile, int pizzaId, CancellationToken cancellationToken)
        {
            var url = await SaveImage(formFile);
            var Img = await _imageRepository.GetImageById(pizzaId, cancellationToken);
            if(Img != null)
            {
                Img.OriginalName = url.Item2;
                Img.Path = url.Item1;

                await _imageRepository.UpdateEntity(cancellationToken, Img);
            }       
            else
            {
                var pizzaImage = new Image
                {
                    PizzaId = pizzaId,
                    Path = url.Item1,
                    OriginalName = url.Item2
                };
                await _imageRepository.AddAsync(cancellationToken, pizzaImage);
            }
        }
    }
}
