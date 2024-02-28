using Microsoft.EntityFrameworkCore;


namespace Mission08_Team0109.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
    }
}
