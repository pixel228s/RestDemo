using PizzaRestaurantDemo.Application.Ranks.Models.Requests;

namespace PizzaRestaurantDemo.Application.Ranks.Interfaces
{
    public interface IRankingService
    {
        Task GiveFeedback(RankRequest request, CancellationToken cancellationToken);
        Task<int?> GetPizzaAverageRankScore(int pizzaId, CancellationToken cancellationToken);
    }
}
