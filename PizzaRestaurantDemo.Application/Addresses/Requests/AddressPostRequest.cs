namespace PizzaRestaurantDemo.Application.Addresses.Requests
{
    public class AddressPostRequest
    {
        public string City { get; set; }
        public string? Region { get; set; }
        public string Country { get; set; }
        public string? Description { get; set; }
    }
}
