using DasherAPI.Data;
using DasherAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DasherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DasherDbContext _db;
        private readonly Endpoints.UserEndpoints _endpoints;
        private readonly Services.UserService _services;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthController(DasherDbContext db, Endpoints.UserEndpoints userEndpoints, Services.UserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _endpoints = userEndpoints;
            _services = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        // POST api/<AuthController>
        [HttpPost ("login")]
        public async Task Login(string email, string password)
        {
            var result = await _endpoints.Login(_services, email, password, _httpContextAccessor.HttpContext);
        }
        // POST api/<AuthController>
        [HttpPost ("register")]
        public async Task<IResult> Register(string email, string password)
        {
            var result = await _endpoints.Register(_services, email, password);
            return result;
        }
    }
}
