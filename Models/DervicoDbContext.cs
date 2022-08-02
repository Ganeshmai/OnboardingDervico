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

        public DbSet<useronboard> useronboard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<users>()
                .HasKey(o => new {o.staffId,});

            modelBuilder.Entity<useronboard>()
              .HasKey(o => new {  o.empId });

            modelBuilder.Entity<useronboard>()
                .Property(o => o.startDate).HasColumnType("date");
        }


      

        
    }
}
