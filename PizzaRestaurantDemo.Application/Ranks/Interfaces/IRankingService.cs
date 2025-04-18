namespace PizzaRestaurantDemo.Application.Ranks.Interfaces
{
    public interface IRankingService
    {
        Task GiveFeedback(int pizzaId,int userId, CancellationToken cancellationToken);
        Task<int?> GetPizzaAverageRankScore(int pizzaId, CancellationToken cancellationToken);
    }
}
