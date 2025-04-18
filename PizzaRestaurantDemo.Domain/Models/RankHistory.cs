using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class RankHistory : BaseEntity
    {
        public int UserId {  get; set; }
        public int PizzaId { get; set; }
        public int Rank { get; set; }   
        public User User { get; set; }
        public Pizza Pizza { get; set; }
    }
}
