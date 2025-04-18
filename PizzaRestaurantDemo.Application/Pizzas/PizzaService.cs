using Mapster;
using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using PizzaRestaurantDemo.Application.Pizzas.Interfaces;
using PizzaRestaurantDemo.Application.Pizzas.Models.Requests;
using PizzaRestaurantDemo.Application.Pizzas.Models.Responses;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Application.Pizzas
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<PizzaExample> AddPizza(PizzaExampleModel example, CancellationToken cancellationToken)
        {
            var existingPizza = await _pizzaRepository.GetPizzaByName(example.Name, cancellationToken);
            if (existingPizza != null)
            {
                throw new ItemAlreadyExistsException();
            }

            var pizza = new Pizza
            {
                CaloryCount = example.CaloryCount,
                Price = example.Price,
                Description = example.Description,
                Name = example.Name,
            };
            await _pizzaRepository.AddAsync(cancellationToken, pizza);
            return pizza.Adapt<PizzaExample>(); 
        }

        public async Task DeletePizza(int id, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaRepository.GetPizzaById(id, cancellationToken); 

            if(pizza == null)
            {
                return;
            }

            pizza.IsDeleted = true;
            await _pizzaRepository.UpdateEntity(cancellationToken, pizza);
        }

        public async Task<IEnumerable<PizzaExample>> GetAllPizzas(CancellationToken cancellationToken)
        {
            var pizzas = await _pizzaRepository.GetAllPizzas(cancellationToken);
            return pizzas.Adapt<IEnumerable<PizzaExample>>();
        }

        public async Task<PizzaExample> GetPizzaExampleById(int id, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaRepository.GetPizzaById(id, cancellationToken);
            if(pizza == null)
            {
                throw new NoSuchItemException();
            }

            return pizza.Adapt<PizzaExample>();
        }

        public async Task<PizzaExample> UpdatePizza(PizzaUpdateModel model, int id, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaRepository.GetPizzaById(id, cancellationToken);

            if(pizza == null)
            {
                throw new NoSuchItemException();
            }

            pizza.CaloryCount = model.CaloryCount ?? pizza.CaloryCount;
            pizza.Description = model.Description ?? pizza.Description;
            pizza.Price = model.Price ?? pizza.Price;
            pizza.Name = model.Name ?? pizza.Name;  

            await _pizzaRepository.UpdateEntity(cancellationToken, pizza);
            return pizza.Adapt<PizzaExample>();
        }

    }
}
