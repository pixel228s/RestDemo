using Microsoft.AspNetCore.Mvc;
using PizzaRestaurantDemo.Application.Infrastructure.Exceptions;
using System.Data;
using System.Net;
using System.Text.Json;

namespace PizzaRestaurantDemo.API.Infrastructure.Extensions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
  
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message,
            };

            switch (exception)
            {
                case UnauthorizedAccessException:
                    problemDetails.Title = "Unauthorized access.";
                    problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                    problemDetails.Type = nameof(UnauthorizedAccessException);
                    break;

                case ArgumentNullException:
                case ArgumentException:
                    problemDetails.Title = "Invalid request data.";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(ArgumentException);
                    break;

                case KeyNotFoundException:
                    problemDetails.Title = "Resource not found.";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Type = nameof(KeyNotFoundException);
                    break;

                case NoSuchItemException:
                    problemDetails.Title = "Item not found.";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Type = nameof(NoSuchItemException);
                    break;

                case InvalidOrderException:
                    problemDetails.Title = "Order not correct.";
                    problemDetails.Status = (int)HttpStatusCode.Forbidden;
                    problemDetails.Type = nameof(InvalidOrderException);
                    break;

                case UserAlreadyExistsException:
                    problemDetails.Title = "Email already exists.";
                    problemDetails.Status = (int)HttpStatusCode.Conflict;
                    problemDetails.Type = nameof(UserAlreadyExistsException);
                    break;

                case UserNotFoundException:
                    problemDetails.Title = "User does not exist";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Type = nameof(UserNotFoundException);
                    break;

                case ConstraintException:
                    problemDetails.Title = "Key constrint error occured";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(ConstraintException);
                    break;
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = JsonSerializer.Serialize(problemDetails, options);
            return context.Response.WriteAsync(result);
        }
    }

}
