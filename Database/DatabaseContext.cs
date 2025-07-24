using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DrinkModel> Drinks { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
