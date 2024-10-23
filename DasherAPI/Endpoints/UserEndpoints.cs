using DasherAPI.Controllers;
using DasherAPI.Services;
using Microsoft.AspNetCore.Routing;
using System.Runtime.CompilerServices;
namespace DasherAPI.Endpoints
{
    public class UserEndpoints
    {

        public async Task<IResult> Register(UserService userService, string email, string password)
        {
            await userService.Register(email, password);

            return Results.Ok();
        }
        public async Task<IResult> Login(UserService userService, string email, string password, HttpContext context)
        {
            var token = await userService.Login(email, password);

            context.Response.Cookies.Append("tasty-cookies", token);

            return Results.Ok();
        }
    }
}
