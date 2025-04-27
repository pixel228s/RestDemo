using PizzaRestaurantDemo.Application.Orders.Requests;
namespace PizzaRestaurantDemo.Application.Orders.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderRequest request, CancellationToken cancellationToken);
    }
}
