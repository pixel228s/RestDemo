using PizzaRestaurantDemo.Application.Pizzas.Models.Requests;
using PizzaRestaurantDemo.Application.Pizzas.Models.Responses;

namespace PizzaRestaurantDemo.Application.Pizzas.Interfaces
{
    public interface IPizzaService
    {
        Task<PizzaExample> AddPizza(PizzaExampleModel pizza, CancellationToken cancellationToken);
        Task<PizzaExample> UpdatePizza(PizzaUpdateModel model, int id, CancellationToken cancellationToken);
        Task DeletePizza(int id, CancellationToken cancellationToken);
        Task<PizzaExample> GetPizzaExampleById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<PizzaExample>> GetAllPizzas(CancellationToken cancellationToken);     
    }
}
