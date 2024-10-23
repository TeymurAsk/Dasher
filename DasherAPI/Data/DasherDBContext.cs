using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DasherAPI.Data
{
    public class DasherDbContext : DbContext
    {
        public DasherDbContext(DbContextOptions<DasherDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
    }
}
