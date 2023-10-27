using System.ComponentModel.DataAnnotations;

namespace Students.Web.Model;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}