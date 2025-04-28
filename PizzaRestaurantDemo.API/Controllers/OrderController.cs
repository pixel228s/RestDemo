using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Application.Orders.Requests;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> AddPizza(OrderRequest request, CancellationToken cancellationToken)
        {
            await _orderService.PlaceOrder(request, cancellationToken);
            return Ok(StatusCodes.Status201Created);
        }
    }
}
