using FluentValidation;
using PizzaRestaurantDemo.Application.Addresses.Requests;

namespace PizzaRestaurantDemo.Application.Infrastructure.Validations
{
    public class AddressValidation : AbstractValidator<AddressPostRequest>
    {
        public AddressValidation() 
        {
            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage("City contains too many characters");

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage("Country contains too many characters");

            RuleFor(x => x.Region)
                .MaximumLength(15)
                .WithMessage("Region contains too many characters");

        }
    }
}
