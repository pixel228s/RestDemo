using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
        public Image Image { get; set; }
        public List<RankHistory> Ranks { get; set; } = new();
        public ICollection<PizzaOrder> Orders { get; set; } = new List<PizzaOrder>();
    }
}
