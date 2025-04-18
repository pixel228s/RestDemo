using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string? Region { get; set; }
        public string Country { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
