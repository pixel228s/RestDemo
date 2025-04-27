using Microsoft.Extensions.DependencyInjection;
using PizzaRestaurantDemo.Application.Users.Interfaces;
using PizzaRestaurantDemo.Application.Users;
using PizzaRestaurantDemo.Infrastructure.Implementations;
using PizzaRestaurantDemo.Application.Pizzas.Interfaces;
using PizzaRestaurantDemo.Application.Pizzas;
using PizzaRestaurantDemo.Application.Orders.Interfaces;
using PizzaRestaurantDemo.Application.Orders;
using PizzaRestaurantDemo.Application.Ranks.Interfaces;
using PizzaRestaurantDemo.Application.Ranks;
using PizzaRestaurantDemo.Application.Images.Interfaces;
using PizzaRestaurantDemo.Application.Images;

namespace PizzaRestaurantDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRankingRepository, RankingRepository>();
            services.AddScoped<IRankingService, RankingService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
