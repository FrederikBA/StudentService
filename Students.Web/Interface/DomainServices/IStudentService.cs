using Students.Web.Model;
using Students.Web.Model.Dto;

namespace Students.Web.Interface.DomainServices;

public interface IStudentService
{
    Task<List<Student>> GetStudentsAsync();
    Task<StudentDto> GetStudentByIdAsync(int id);
    Task<Student> CreateStudentAsync(StudentDto studentDto);
}