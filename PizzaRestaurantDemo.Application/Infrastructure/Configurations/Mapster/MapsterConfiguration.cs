using Microsoft.Extensions.DependencyInjection;
using PizzaRestaurantDemo.Domain.Models;
using Mapster;
using PizzaRestaurantDemo.Application.Users;
using PizzaRestaurantDemo.Application.Pizzas.Models.Responses;
using PizzaRestaurantDemo.Application.Orders.Responses;


namespace PizzaRestaurantDemo.Application.Infrastructure.Configurations.Mapster
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<User, UserService>
                .NewConfig()
                .TwoWays();

            //TypeAdapterConfig<Address, AddressResponse>
            //    .NewConfig()
            //    .TwoWays();

            TypeAdapterConfig<Pizza, PizzaExample>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Order, OrderResponse>
                .NewConfig()
                .TwoWays();
        }
    }
}
