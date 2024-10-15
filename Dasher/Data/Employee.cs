using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dasher.Data
{
    public class Employee
    {
        [Key] // Use UserID as the primary key
        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Job Title")]
        public string JobTitle { get; set; }

        [Column(TypeName = "integer")] 
        public int HourlyPay { get; set; }

        [Column(TypeName = "boolean")] 
        public bool IsAvailableNow { get; set; } 

        [Range(0.0, 5.0)]
        [Column(TypeName = "numeric(3, 1)")] 
        public decimal Rating { get; set; } 

        [Column("Comments Count")]
        public int CommentsCount { get; set; } = 0; 

        [Column("Profile Picture")]
        public byte[] ProfilePicture { get; set; } 

        [Column("Bio")]
        public string Bio { get; set; } 
    }
}