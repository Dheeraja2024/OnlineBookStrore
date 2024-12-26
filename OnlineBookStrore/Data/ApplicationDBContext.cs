using Microsoft.EntityFrameworkCore;
using OnlineBookStrore.Models;

namespace OnlineBookStrore.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Action", DisplayOrder = 1 },
                                                    new Category() { Id = 2, Name = "sifi", DisplayOrder = 2 },
                                                    new Category() { Id = 3, Name = "History", DisplayOrder = 3 });
        }

    }
}
