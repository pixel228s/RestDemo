namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class ImageFormatNotAllowedException : Exception
    {
        public ImageFormatNotAllowedException(string? message = "Invalid image format.") : base(message)
        {
        }
    }
}
