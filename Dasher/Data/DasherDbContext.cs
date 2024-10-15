using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Dasher.Data
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
