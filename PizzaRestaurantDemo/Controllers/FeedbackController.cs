using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Ranks.Interfaces;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public FeedbackController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAverageScore(int pizzaId, CancellationToken cancellationToken)
        {
            double? score = await _rankingService.GetPizzaAverageRankScore(pizzaId, cancellationToken);
            return Ok(new { RankScore = score });
        }
    }
}
