using PizzaRestaurantDemo.Application.Addresses.Responses;

namespace PizzaRestaurantDemo.Application.Users.Responses
{
    public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressResponse Address { get; set; }
    }
}
