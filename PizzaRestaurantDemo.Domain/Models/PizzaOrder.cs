namespace PizzaRestaurantDemo.Domain.Models
{
    public class PizzaOrder
    {
        public int OrderId {  get; set; }
        public int PizzaId { get; set; }
        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
