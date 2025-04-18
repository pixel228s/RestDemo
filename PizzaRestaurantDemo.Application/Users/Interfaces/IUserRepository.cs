using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure;

namespace PizzaRestaurantDemo.Application.Users.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Task AddUser(User user, CancellationToken cancellationToken);
        Task<User> GetUserById(int id, CancellationToken cancellationToken);
        Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<User> GetUserInfoById(int id, CancellationToken cancellationToken);
    }
}
