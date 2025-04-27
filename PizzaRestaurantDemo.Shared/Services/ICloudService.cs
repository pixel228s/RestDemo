using PizzaRestaurantDemo.Shared.Models;

namespace PizzaRestaurantDemo.Shared.Services
{
    public interface ICloudService
    {
        Task UploadFileAsync(S3ObjectMod S3obj, AWSCredentialsCustom awsCredentials);
        Task DeleteFileAsync(S3ObjectMod S3obj, AWSCredentialsCustom awsCredentials);
    }
}
