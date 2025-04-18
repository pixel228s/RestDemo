using PizzaRestaurantDemo.Application.Users.Requests;
using PizzaRestaurantDemo.Application.Users.Responses;

namespace PizzaRestaurantDemo.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> AddUser(UserPostRequest request, CancellationToken cancellationToken);
        Task<UserResponse> UpdateUserById(int id, UserPutRequest request, CancellationToken cancellationToken);
        Task DeactivateUserById(int id, CancellationToken cancellationToken);
        Task<UserResponse> GetUserById(int id, CancellationToken cancellationToken);
        Task<UserResponse> UpdateUserAddress(int id, UserAddressUpdateRequest request, CancellationToken cancellationToken);
    }
}
