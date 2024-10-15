using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dasher.Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(100)]
        [Column("First Name")]
        public string Firstname { get; set; }

        [StringLength(100)]
        [Column("Last Name")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(255)]
        [Column("PasswordHash")]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }

        [StringLength(20)]
        [Column("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Role")]
        public string Role { get; set; } // "Owner" or "Employee"

        [Column("Is Active")]
        public bool IsActive { get; set; } = true;

        [Column("Date Created", TypeName = "timestamp")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Column("Last Login", TypeName = "timestamp")]
        public DateTime? LastLogin { get; set; }
    }
}