using Microsoft.EntityFrameworkCore;

namespace OnboardingDervico.Models
{
    public class DervicoDbContext : DbContext
    {

        public DervicoDbContext(DbContextOptions<DervicoDbContext> options) :base (options)
        {

        }

        public DbSet<users> users { get; set; }

        public DbSet<role> role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<users>()
                .HasKey(o => new {o.userId,o.staffId});
        }


      

        
    }
}
