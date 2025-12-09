using Microsoft.EntityFrameworkCore;
using ProjectTest.Model;

namespace ProjectTest.Data
{
    public class ProjectTestDbContext: DbContext
    {
        public ProjectTestDbContext(DbContextOptions<ProjectTestDbContext> options):base(options)
        {


        }

        public DbSet<Product> Product{ get; set; }

    }
}
