using Microsoft.EntityFrameworkCore;

namespace RazorCrud.Models
{
    public class RazorContext:DbContext
    {
        public RazorContext(DbContextOptions<RazorContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
