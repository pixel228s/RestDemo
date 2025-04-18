using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure;

namespace PizzaRestaurantDemo.Application.Pizzas.Interfaces
{
    public interface IPizzaRepository : IBaseRepository<Pizza>
    {
        Task<IEnumerable<Pizza>> GetAllPizzas(CancellationToken cancellationToken);
        Task<Pizza?> GetPizzaById(int id, CancellationToken cancellationToken);
        Task<Pizza?> GetPizzaByName(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Pizza>> GetPizzasByMultipleId(CancellationToken cancellationToken, params int[] pizzaIds);
    }
}
