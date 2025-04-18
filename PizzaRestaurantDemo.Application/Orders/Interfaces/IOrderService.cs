using PizzaRestaurantDemo.Application.Orders.Requests;
using PizzaRestaurantDemo.Application.Orders.Responses;
namespace PizzaRestaurantDemo.Application.Orders.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderRequest request, CancellationToken cancellationToken);
    }
}
