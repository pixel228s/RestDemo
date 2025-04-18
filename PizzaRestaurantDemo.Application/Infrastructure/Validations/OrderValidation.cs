using FluentValidation;
using PizzaRestaurantDemo.Application.Orders.Requests;

namespace PizzaRestaurantDemo.Application.Infrastructure.Validations
{
    public class OrderValidation : AbstractValidator<OrderRequest>
    {
        public OrderValidation()
        {
            RuleFor(x => x.pizzas)
                .NotEmpty();
        }
    }
}
