using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class Image : BaseEntity
    {
        public string OriginalName { get; set; }
        public string Path { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
