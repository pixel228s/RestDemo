using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Application.Orders.Responses;
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

        public Task<OrderResponse> GetOrderById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
