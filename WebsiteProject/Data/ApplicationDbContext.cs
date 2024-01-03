using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteProject.Models;

namespace WebsiteProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<WebsiteProject.Models.Services> Services { get; set; }
        public DbSet<WebsiteProject.Models.Clients> Clients { get; set; }
    }
}