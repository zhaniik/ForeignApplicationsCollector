using ForeignApplicationsCollector.Models;
using Microsoft.EntityFrameworkCore;

namespace ForeignApplicationsCollector.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
