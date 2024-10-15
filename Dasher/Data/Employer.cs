using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dasher.Data
{
    public class Employer
    {
        [Key]
        [ForeignKey("User")] 
        public int UserId { get; set; } 
        public User User { get; set; }

        [Column(TypeName = "text")]
        public string Favorites { get; set; }

        [Column(TypeName = "text")]
        public string Requested { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
    }
}