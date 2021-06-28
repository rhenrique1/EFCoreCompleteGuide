using Microsoft.EntityFrameworkCore;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        // public DbSet<Genre> Genres { get; set; }
    }
}