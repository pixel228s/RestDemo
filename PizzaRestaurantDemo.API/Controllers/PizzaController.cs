using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Pizzas.Interfaces;
using PizzaRestaurantDemo.Application.Pizzas.Models.Requests;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("pizza-list")]
        public async Task<IActionResult> GetAllPizzaInfo(CancellationToken cancellationToken)
        {
            var pizzas = await _pizzaService.GetAllPizzas(cancellationToken);
            return Ok(pizzas);
        }

        [HttpGet("pizza/{id}")]
        public async Task<IActionResult> GetPizza(int id, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaService.GetPizzaExampleById(id, cancellationToken);
            return Ok(pizza);
        }

        [HttpPost("add-pizza")]
        public async Task<IActionResult> AddPizza(PizzaExampleModel request, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaService.AddPizza(request, cancellationToken);
            return Ok(pizza);
        }

        [HttpPut("update-pizza")]
        public async Task<IActionResult> UpdatePizzaById(PizzaUpdateModel request, int id, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaService.UpdatePizza(request, id, cancellationToken); 
            return Ok(pizza);
        }
    }
}
