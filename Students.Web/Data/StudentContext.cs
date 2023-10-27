using Microsoft.EntityFrameworkCore;
using Students.Web.Model;

namespace Students.Web.Data;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
        
    }
}