using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public ICollection<PizzaOrder> Pizzas { get; set; } = new List<PizzaOrder>();

        /* navigation properties */
        public User User { get; set; }
        public Address Address { get; set; }    
    }
}
