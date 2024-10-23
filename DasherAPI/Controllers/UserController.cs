using DasherAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DasherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DasherDbContext _db;
        public UserController(DasherDbContext db)
        {
            _db = db;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            return _db.Users.ToList();
        }
        [HttpGet("{email}")]
        public async Task<User> GetByEmail(string email)
        {
            return _db.Users.SingleOrDefault(u => u.Email == email);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            if (user == null)
            {
                BadRequest("Item data is null");
            }
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _db.Users.Find(id).Firstname = user.Firstname;
            _db.Users.Find(id).Lastname = user.Lastname;
            _db.Users.Find(id).PasswordHash = user.PasswordHash;
            _db.Users.Find(id).Email = user.Email;
            _db.Users.Find(id).PhoneNumber = user.PhoneNumber;
            _db.Users.Find(id).Role = user.Role;
            _db.Users.Find(id).IsActive = user.IsActive;
            _db.Users.Find(id).DateCreated = user.DateCreated;
            _db.Users.Find(id).LastLogin = user.LastLogin;
            _db.SaveChanges();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Users.Remove(_db.Users.Find(id));
            _db.SaveChanges();
        }
    }
}
