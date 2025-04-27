using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.API.Infrastructure.Extensions;
using PizzaRestaurantDemo.API.Infrastructure.Middlewares;
using PizzaRestaurantDemo.Application.Infrastructure.Configurations;
using PizzaRestaurantDemo.Application.Infrastructure.Configurations.Mapster;
using PizzaRestaurantDemo.Infrastructure;
using PizzaRestaurantDemo.Persistence.Data;
using PizzaRestaurantDemo.Shared.Services;

namespace PizzaRestaurantDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<PizzaRestaurantDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<ICloudService, CloudService>();

            builder.Services
                .AddSwaggerDocumentation()
                .InjectServices()
                .AddValidations()
                .RegisterMaps();
         

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionHandler>();
            app.UseMiddleware<CultureMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
