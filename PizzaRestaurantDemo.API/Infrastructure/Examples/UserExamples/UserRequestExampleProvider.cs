using PizzaRestaurantDemo.Application.Addresses.Requests;
using PizzaRestaurantDemo.Application.Users.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurantDemo.API.Infrastructure.Examples.UserExamples
{
    public class UserRequestExampleProvider : IMultipleExamplesProvider<UserPostRequest>
    {
        public IEnumerable<SwaggerExample<UserPostRequest>> GetExamples()
        {
            yield return SwaggerExample.Create("User with address", new UserPostRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "JohnDoe@gmail.com",
                PhoneNumber = "555655667",
                Address = new AddressPostRequest
                {
                    City = "Tbilisi",
                    Region = "Tbilisi",
                    Description = "some description",
                    Country = "Georgia"
                }
            });
        }
    }
}
