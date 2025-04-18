using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaRestaurantDemo.Application.Infrastructure.Configurations
{
    public static class AddAutoValidation
    {
        public static IServiceCollection AddValidations(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation();
            service.AddValidatorsFromAssembly(typeof(AddAutoValidation).Assembly);
            return service;
        }
    }
}
