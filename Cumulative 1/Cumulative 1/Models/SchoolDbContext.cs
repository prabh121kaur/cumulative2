using Microsoft.EntityFrameworkCore;

namespace Cumulative_1.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
