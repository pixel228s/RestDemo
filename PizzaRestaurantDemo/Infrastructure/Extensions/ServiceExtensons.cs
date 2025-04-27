using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace PizzaRestaurantDemo.API.Infrastructure.Extensions
{
    public static class ServiceExtensons
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.ExampleFilters();
            });
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
