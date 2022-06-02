using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Shared.Models;

namespace WesiteWebApi.Models
{
    public class WebsiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebsiteDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
    }
}
