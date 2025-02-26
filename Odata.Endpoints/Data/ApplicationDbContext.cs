using Microsoft.EntityFrameworkCore;

namespace Odata.Endpoints.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(_ => _.Category)
                .WithMany(c => c.products)
                .HasForeignKey(_ => _.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
