namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class NoSuchItemException : Exception
    {
        public NoSuchItemException(string? message = "No such item available.") : base(message)
        {
        }
    }
}
