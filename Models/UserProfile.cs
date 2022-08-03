namespace OnboardingDervico.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProfile    
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int profileId { get; set; }

        
        public string staffId { get; set; }

        [ForeignKey("staffId")]
        public users Users { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }

        public DateTime startDate { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string RecentActivity { get; set; }
    }
}
