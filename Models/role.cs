using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingDervico.Models
{
    public class role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roleId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string roleName { get; set; }

        [Required]
        public int rolePriority { get; set; }

    }
}
