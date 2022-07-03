using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingDervico.Models
{
    public class users
    {
        [ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [ DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(7)")]
        public string staffId { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string fullName { get; set; }

        [EmailAddress]
        public string emailId { get; set; }


        [Column(TypeName = "varchar(15)")]
        public string mobileNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime joiningDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string odcName { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string designation { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string location { get; set; }

        [Required]
        public int roleId { get; set; }

        [ForeignKey("roleId")]
        public role role { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string authType { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required]
        public int lockcount { get; set; }


    }
}
