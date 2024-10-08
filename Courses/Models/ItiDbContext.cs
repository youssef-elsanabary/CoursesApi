using Microsoft.EntityFrameworkCore;

namespace Courses.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() { }
        public ITIContext(DbContextOptions<ITIContext> options) : base (options) { }
        public DbSet<Course> Courses { get; set; }
  //      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //      {
  //          optionsBuilder.UseSqlServer(
  //                "Server=YOUSSEF\\SQLEXPRESS;Initial Catalog = CourseApi ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
  //);
  //          base.OnConfiguring(optionsBuilder);
  //      }
    }
    
}
