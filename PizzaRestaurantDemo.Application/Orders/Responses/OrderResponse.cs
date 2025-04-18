using PizzaRestaurantDemo.Application.Pizzas.Models.Responses;
using PizzaRestaurantDemo.Application.Users.Responses;

namespace PizzaRestaurantDemo.Application.Orders.Responses
{
    public class OrderResponse
    {
        public List<PizzaExample> Pizzas { get; set; }
        public UserResponse User { get; set; }
    }
}
