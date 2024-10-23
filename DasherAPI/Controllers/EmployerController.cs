using DasherAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DasherAPI.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DasherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "EmployerPolicy")]
    public class EmployerController : ControllerBase
    {
        private readonly DasherDbContext _db;
        public EmployerController(DasherDbContext db)
        {
            _db = db;
        }
        // GET: api/<EmployersController>
        [HttpGet]
        public List<Employer> Get()
        {
            return _db.Employers.ToList();
        }

        // GET api/<EmployersController>/5
        [HttpGet("{id}")]
        public Employer Get(int id)
        {
            return _db.Employers.Find(id);
        }

        // POST api/<EmployersController>
        [HttpPost]
        public void Post([FromBody] Employer employer)
        {
            if (employer == null)
            {
                BadRequest("Item data is null");
            }
            _db.Employers.Add(employer);
            _db.SaveChanges();
        }

        // PUT api/<EmployersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employer employer)
        {
            _db.Employers.Find(id).Favorites = employer.Favorites;
            _db.Employers.Find(id).Requested = employer.Requested;
            _db.Employers.Find(id).CompanyName = employer.CompanyName;
            _db.SaveChanges();
        }

        // DELETE api/<EmployersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Employers.Remove(_db.Employers.Find(id));
            _db.SaveChanges();
        }
    }
}
