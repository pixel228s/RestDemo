using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Application.Pizzas.Interfaces;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure.Implementations.Base;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaRestaurantDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas(CancellationToken cancellationToken)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);  
        }

        public Task<Pizza?> GetPizzaById(int id, CancellationToken cancellationToken)
        {
            var pizza = _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return pizza;
        }

        public Task<Pizza?> GetPizzaByName(string name, CancellationToken cancellationToken)
        {
            return _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }

        public async Task<IEnumerable<Pizza>> GetPizzasByMultipleId(CancellationToken cancellationToken, int[] pizzaIds)
        {
            var pizzas = await _dbSet
                .AsNoTracking()
                .Where(p => pizzaIds.Contains(p.Id))
                .ToListAsync(cancellationToken);
            return pizzas;
        }
    }
}
