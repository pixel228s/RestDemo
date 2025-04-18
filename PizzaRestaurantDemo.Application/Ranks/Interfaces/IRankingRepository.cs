using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure;

namespace PizzaRestaurantDemo.Application.Ranks.Interfaces
{
    public interface IRankingRepository : IBaseRepository<RankHistory>
    {
        Task<int?> GetAverageRankScoreByPizzaId(int pizzaId, CancellationToken cancellationToken);
    }
}
