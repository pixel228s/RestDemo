using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Application.Orders.Requests;
using PizzaRestaurantDemo.Application.Pizzas.Interfaces;
using PizzaRestaurantDemo.Application.Users.Interfaces;
using PizzaRestaurantDemo.Domain.Models;

namespace PizzaRestaurantDemo.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;

        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, IPizzaRepository pizzaRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task PlaceOrder(OrderRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var pizzas = await _pizzaRepository.GetPizzasByMultipleId(cancellationToken, request.pizzas);
            if(pizzas == null || pizzas.Count() != request.pizzas.Length)
            {
                throw new InvalidOrderException();
            }
            var order = new Order
            {
                AddressId = user.Address.Id,
                UserId = request.UserId,
                Pizzas = pizzas.Select(pizza => new PizzaOrder
                {
                    PizzaId = pizza.Id
                }).ToList()
            };

            await _orderRepository.AddAsync(cancellationToken, order);
        }
    }
}
