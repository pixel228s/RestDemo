using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Application.Ranks.Interfaces;
using PizzaRestaurantDemo.Application.Ranks.Models.Requests;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Application.Ranks
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IOrderRepository _orderRepository;
        public RankingService(IRankingRepository rankingRepository, IOrderRepository orderRepository)
        {
            _rankingRepository = rankingRepository;
            _orderRepository = orderRepository;
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

        public async Task GiveFeedback(RankRequest request,  CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.UserId, request.PizzaId, cancellationToken);
            if(order is null)
            {
                throw new NoSuchItemException();
            }
            var rank = new RankHistory
            {
                UserId = request.UserId,
                Rank = request.Score,
                PizzaId = request.PizzaId,
            };
            await _rankingRepository.AddAsync(cancellationToken, rank);
        }
    }
}
