using BackeryBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }  
        public DbSet<OrderProduct> OrderProduct { get; set; }
    }
}
