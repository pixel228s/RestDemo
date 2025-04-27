namespace PizzaRestaurantDemo.Application.Ranks.Models.Requests
{
    public class RankRequest
    {
        public int Score {  get; set; }
        public int PizzaId { get; set; }
        public int UserId { get; set; }
    }
}
