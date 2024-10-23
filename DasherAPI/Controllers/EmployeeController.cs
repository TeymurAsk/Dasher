using DasherAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DasherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "EmployeePolicy")]
    public class EmployeeController : ControllerBase
    {
        private readonly DasherDbContext _db;
        public EmployeeController(DasherDbContext db)
        {
            _db = db;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public List<Employee> Get()
        {
            return _db.Employees.ToList();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                BadRequest("Item data is null");
            }
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _db.Employees.Find(id).JobTitle = employee.JobTitle;
            _db.Employees.Find(id).HourlyPay = employee.HourlyPay;
            _db.Employees.Find(id).IsAvailableNow = employee.IsAvailableNow;
            _db.Employees.Find(id).Rating = employee.Rating;
            _db.Employees.Find(id).CommentsCount = employee.CommentsCount;
            _db.Employees.Find(id).ProfilePicture = employee.ProfilePicture;
            _db.Employees.Find(id).Bio = employee.Bio;
            _db.SaveChanges();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Employees.Remove(_db.Employees.Find(id));
            _db.SaveChanges();
        }
    }
}
