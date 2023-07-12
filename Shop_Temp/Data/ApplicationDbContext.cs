using Microsoft.EntityFrameworkCore;
using ShopRazor_Temp.Models;

namespace ShopRazor_Temp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { id = 1, name = "Action", DisplayOrder = 1 },
            new Category { id = 2, name = "SciFi", DisplayOrder = 2 },
            new Category { id = 3, name = "Histori", DisplayOrder = 3 }
            );
    }
}
