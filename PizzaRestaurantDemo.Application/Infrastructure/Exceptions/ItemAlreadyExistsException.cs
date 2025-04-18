namespace PizzaRestaurantDemo.Application.Infrastructure.Exceptions
{
    public class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException() { }

        public ItemAlreadyExistsException(string? message = "Item already exists.") : base(message)
        {
        }
    }
}
