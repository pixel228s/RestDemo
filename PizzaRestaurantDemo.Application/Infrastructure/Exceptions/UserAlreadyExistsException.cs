namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string? message = "User already exists.") : base(message)
        {
        }
    }
}
