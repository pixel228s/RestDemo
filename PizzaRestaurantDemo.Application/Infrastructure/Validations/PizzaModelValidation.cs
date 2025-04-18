using FluentValidation;
using PizzaRestaurantDemo.Application.Pizzas.Models.Requests;

namespace PizzaRestaurantDemo.API.Infrastructure.Validations
{
    public class PizzaModelValidation : AbstractValidator<PizzaExampleModel>
    {
        public PizzaModelValidation()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Please, input correct price");

            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithMessage("Name length not allowed");

            RuleFor(p => p.Description)
                .MaximumLength(100)
                .WithMessage("Description length not allowed");

            RuleFor(p => p.CaloryCount)
               .GreaterThan(0)
               .WithMessage("Please, make sure calory count is more than 0.");
        }
    }
}
