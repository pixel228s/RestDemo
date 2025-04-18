using PizzaRestaurantDemo.Application.Orders.Responses;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure;

namespace PizzaRestaurantDemo.Application.Orders.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<OrderResponse> GetOrderById(int id, CancellationToken cancellationToken);
    }
}
