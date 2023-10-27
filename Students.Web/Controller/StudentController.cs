using Microsoft.AspNetCore.Mvc;
using Students.Web.Interface.DomainServices;
using Students.Web.Model.Dto;

namespace Students.Web.Controller;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync()
    {
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentByIdAsync(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return Ok(student);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudentAsync(StudentDto studentDto)
    {
        var createdStudent = await _studentService.CreateStudentAsync(studentDto);
        return Ok(createdStudent);
    }
}