using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Application.Ranks.Interfaces;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure.Implementations.Base;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations
{
    public class RankingRepository : BaseRepository<RankHistory>, IRankingRepository
    {
        public RankingRepository(PizzaRestaurantDbContext context) : base(context)
        {
        }

        public async Task<int?> GetAverageRankScoreByPizzaId(int pizzaId, CancellationToken cancellationToken)
        {
            return (int?)await _dbSet
                .AsNoTracking()
                .Where(x => x.PizzaId == pizzaId)
                .Select(x => (int?)x.Rank)
                .AverageAsync(cancellationToken);            
        }
    }
}
