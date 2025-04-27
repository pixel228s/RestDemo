using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using PizzaRestaurantDemo.Shared.Models;

namespace PizzaRestaurantDemo.Shared.Services
{
    public class CloudService : ICloudService
    {
        public async Task DeleteFileAsync(S3ObjectMod S3obj, AWSCredentialsCustom awsCredentials)
        {
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSouth1
            };

            var response = new S3ResponseModel();

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = S3obj.BucketName,
                Key = S3obj.Name,
            };

            using var client = new AmazonS3Client(credentials, config);
            var transferUtiliy = new TransferUtility(client);

            await client.DeleteObjectAsync(deleteRequest);
        }

        public async Task UploadFileAsync(S3ObjectMod S3obj, AWSCredentialsCustom  awsCredentials)
        {
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSouth1
            };

            var response = new S3ResponseModel();

            var uploadRequest = new TransferUtilityUploadRequest()
            {
                InputStream = S3obj.InputStream,
                Key = S3obj.Name,
                BucketName = S3obj.BucketName,
                CannedACL = S3CannedACL.NoACL,
            };

            using var client = new AmazonS3Client(credentials, config);
            var transferUtiliy = new TransferUtility(client);

            await transferUtiliy.UploadAsync(uploadRequest);
        }
    }
}
