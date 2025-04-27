namespace PizzaRestaurantDemo.Shared.Models
{
    public class S3ObjectMod
    {
        public string Name { get; set; } = default!;
        public MemoryStream InputStream { get; set; } = default!;
        public string BucketName { get; set; } = default!;
    }
}
