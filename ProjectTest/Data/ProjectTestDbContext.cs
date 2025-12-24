using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectTest.Model;

namespace ProjectTest.Data
{
    public class ProjectTestDbContext: DbContext
    {

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderLine> OrderLine { get; set; }

        public ProjectTestDbContext(DbContextOptions<ProjectTestDbContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasOne(o => o.Product)
                .WithOne(p => p.OrderLine)
                .HasForeignKey<OrderLine>(o => o.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderLines)
                .WithOne(o1 => o1.Order)
                .HasForeignKey(o1 => o1.OrderLineId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
