using PizzaRestaurantDemo.Application.Addresses.Requests;
namespace PizzaRestaurantDemo.Application.Users.Requests
{
    public class UserPostRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressPostRequest? Address { get; set; }
    }
}
