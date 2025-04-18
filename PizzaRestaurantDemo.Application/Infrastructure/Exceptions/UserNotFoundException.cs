namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string? message = "User does not exist.") : base(message)
        {
        }
    }
}
