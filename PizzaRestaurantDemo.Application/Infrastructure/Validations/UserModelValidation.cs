using FluentValidation;
using PizzaRestaurantDemo.Application.Infrastructure.Validations;
using PizzaRestaurantDemo.Application.Users.Requests;


namespace PizzaRestaurantDemo.API.Infrastructure.Validations
{
    public class UserModelValidation : AbstractValidator<UserPostRequest>
    {
        public UserModelValidation()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                .WithMessage("Invalid email format.");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty()
                .Matches(@"(^568|555|557|599|558|593|514|597|592|571|574|579)\d{6}$")
                .WithMessage("Invalid phone number format.");

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(user => user.Address)
                .SetValidator(new AddressValidation())
                .When(user => user.Address != null);
        }
    }
}
