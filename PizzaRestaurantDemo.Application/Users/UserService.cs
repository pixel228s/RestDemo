using Mapster;
using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using PizzaRestaurantDemo.Application.Users.Interfaces;
using PizzaRestaurantDemo.Application.Users.Requests;
using PizzaRestaurantDemo.Application.Users.Responses;
using PizzaRestaurantDemo.Domain.Models;
using System.Security.Claims;

namespace PizzaRestaurantDemo.Application.Users
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeactivateUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(id, cancellationToken);

            if(user == null)
            {
                throw new UserNotFoundException();
            }
            user.IsDeleted = true;
            user.Address.IsDeleted = true;

            await _userRepository.UpdateEntity(cancellationToken, user);
        }

        public async Task<UserResponse> AddUser(UserPostRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email, cancellationToken);
            if(user != null)
            {
                throw new UserAlreadyExistsException();
            }

            var userModel = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Address = new Address
                {
                    City = request.Address.City,
                    Country = request.Address.Country,
                    Region = request.Address.Region,
                    Description = request.Address.Description,
                }
            };

            await _userRepository.AddAsync(cancellationToken, userModel);

            return userModel.Adapt<UserResponse>();
        }

        public async Task<UserResponse> UpdateUserById(int id, UserPutRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserInfoById(id, cancellationToken);

            if(user is null)
            {
                throw new UserNotFoundException();
            }

            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            user.Email = request.Email ?? user.Email;

            await _userRepository.UpdateEntity(cancellationToken, user);
            return user.Adapt<UserResponse>();
        }

        public async Task<UserResponse> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(id, cancellationToken);

            if(user == null)
            {
                throw new UserNotFoundException();
            }

            return user.Adapt<UserResponse>();
        }

        public async Task<UserResponse> UpdateUserAddress(int id, UserAddressUpdateRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(id, cancellationToken);
            if(user is null)
            {
                throw new UserNotFoundException();
            }

            user.Address.Country = request.Country ?? user.Address.Country;
            user.Address.City = request.City ?? user.Address.City;
            user.Address.Region = request.Region ?? user.Address.Region;

            await _userRepository.UpdateEntity(cancellationToken, user);

            return user.Adapt<UserResponse>();
        }
    }
}
