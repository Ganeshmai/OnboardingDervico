using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingDervico.Models
{
    public class useronboard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [Required]
        [Key]
        [Column(TypeName = "varchar(7)")]
        public string empId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string surname { get; set; }

        [EmailAddress]
        public string emailId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string businessUnit { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string department { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string team { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string subTeam { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string position { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string jobProfile { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string location { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string derivcoManager { get; set; }

        public DateTime startDate { get; set; }

        public string costCentre { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string gender { get; set; }


    }
}
