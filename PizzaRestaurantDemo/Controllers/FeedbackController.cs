using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Ranks.Interfaces;
using PizzaRestaurantDemo.Application.Ranks.Models.Requests;

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

        [HttpGet("average-feedback")]
        public async Task<IActionResult> GetAverageScore(int pizzaId, CancellationToken cancellationToken)
        {
            double? score = await _rankingService.GetPizzaAverageRankScore(pizzaId, cancellationToken);
            return Ok(new { RankScore = score });
        }

        [HttpPost("send-feedback")]
        public async Task<IActionResult> SendFeedbackAboutPizza(RankRequest request, CancellationToken cancellationToken)
        {
            await _rankingService.GiveFeedback(request, cancellationToken);
            return Ok(new
            {
                Message = $"Your feedback has been sent successfully with score - {request.Score}"
            });
        }
    }
}
