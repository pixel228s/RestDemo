namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string? message = "Order not valid.") : base(message)
        {
        }
    }
}
