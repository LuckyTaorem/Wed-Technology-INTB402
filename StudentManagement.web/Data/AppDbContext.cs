using Microsoft.EntityFrameworkCore;
using StudentManagement.web.Models.Entities;

namespace StudentManagement.web.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
               
        }
        public DbSet<Student> Students { get; set; }
    }
}
