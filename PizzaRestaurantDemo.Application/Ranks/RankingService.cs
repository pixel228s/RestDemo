using PizzaRestaurantDemo.Application.Ranks.Interfaces;

namespace PizzaRestaurantDemo.Application.Ranks
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task<int?> GetPizzaAverageRankScore(int pizzaId, CancellationToken cancellationToken)
        {
            int? score = await _rankingRepository.GetAverageRankScoreByPizzaId(pizzaId, cancellationToken);

            if(score == null)
            {
                return -1;
            }
            return score;
        }

        public Task GiveFeedback(int pizzaId, int userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
