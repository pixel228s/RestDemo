using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure.Implementations.Base;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaRestaurantDbContext context) : base(context)
        {
        }

        public Task<Order?> GetOrderById(int id, int pizzaId,  CancellationToken cancellationToken)
        {
            var order =  _dbSet
                .AsNoTracking()
                .Where(x => x.UserId == id && x.Pizzas.Any(p => p.PizzaId == pizzaId))
                .FirstOrDefaultAsync(cancellationToken);
            return order;
        }
    }
}
