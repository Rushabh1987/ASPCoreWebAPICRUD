using ASPCoreWebAPICRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student>students { get; set; }
    }
}
