using PizzaRestaurantDemo.Application.Pizzas.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurantDemo.API.Infrastructure.Examples.PizzaExamples
{
    public class PizzaRequestExampleProvider : IMultipleExamplesProvider<PizzaExampleModel>
    {
        public IEnumerable<SwaggerExample<PizzaExampleModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Pepperoni pizza", new PizzaExampleModel
            {
                Name = "პეპერონი",
                CaloryCount = 2000,
                Price = 20.99M,
                Description = "Description",
            });

            yield return SwaggerExample.Create("Vegan pizza", new PizzaExampleModel
            {
                Name = "სამარხვო",
                CaloryCount = 1000,
                Price = 15.99M,
                Description = "Description",
            });

        }
    }
}
