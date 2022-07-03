using Microsoft.EntityFrameworkCore;
using Domain.Entity;
namespace Proj_3.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Team> Teams { get; set; }

    }
}