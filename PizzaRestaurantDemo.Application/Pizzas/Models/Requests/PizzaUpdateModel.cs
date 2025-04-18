namespace PizzaRestaurantDemo.Application.Pizzas.Models.Requests
{
    public class PizzaUpdateModel
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public double? CaloryCount { get; set; }
    }
}
