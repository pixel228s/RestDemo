using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Users.Interfaces;
using PizzaRestaurantDemo.Application.Users.Requests;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PizzaRestaurantDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        [SwaggerResponse(409, "User already exists")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> AddUser([FromBody, Required] UserPostRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.AddUser(request, cancellationToken);
            return Ok(user);
        }

        [HttpPut("deactivate-user/{id}")]
        public async Task<IActionResult> DeactivateUser(int id, CancellationToken cancellationToken)
        {
            await _userService.DeactivateUserById(id, cancellationToken);
            return Ok(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUserById(id, cancellationToken);  
            return Ok(response);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUserInfoById(int id, UserPutRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.UpdateUserById(id, request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update-address/{id}")]
        public async Task<IActionResult> UpdateUserAddressById(int id, UserAddressUpdateRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.UpdateUserAddress(id, request, cancellationToken);
            return Ok(response);
        }
    }
}
