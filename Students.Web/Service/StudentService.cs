using Students.Web.Exceptions;
using Students.Web.Interface.DomainServices;
using Students.Web.Interface.Repositories;
using Students.Web.Model;
using Students.Web.Model.Dto;

namespace Students.Web.Service;

public class StudentService : IStudentService
{
    private readonly IReadRepository<Student> _studentReadRepository;
    private readonly IRepository<Student> _studentRepository;

    public StudentService(IReadRepository<Student> studentReadRepository, IRepository<Student> studentRepository)
    {
        _studentReadRepository = studentReadRepository;
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        var students = await _studentReadRepository.ListAsync();
        return students;
    }

    public async Task<StudentDto> GetStudentByIdAsync(int id)
    {
        var student = await _studentReadRepository.GetByIdAsync(id);
        if (student != null)
        {
            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
            return studentDto;
        }
        else
        {
            throw new StudentNotFoundException(id);
        }
    }

    public Task<Student> CreateStudentAsync(StudentDto studentDto)
    {
        var studentToCreate = new Student
        {
            Id = studentDto.Id,
            Name = studentDto.Name,
            Email = studentDto.Email
        };

        var createdStudent = _studentRepository.AddAsync(studentToCreate);

        return createdStudent;
    }
}