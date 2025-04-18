namespace PizzaRestaurantDemo.Application.Orders.Requests
{
    public class OrderRequest
    {
        public int UserId { get; set; }
        public int[] pizzas { get; set; } = [];
    }
}
