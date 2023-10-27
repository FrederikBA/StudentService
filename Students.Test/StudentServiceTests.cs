using Moq;
using Students.Web.Exceptions;
using Students.Web.Interface.Repositories;
using Students.Web.Model;
using Students.Web.Service;

namespace Students.Test;

public class StudentServiceTests
{
    private readonly StudentService _studentService;
    private readonly Mock<IReadRepository<Student>> _readRepoMock = new Mock<IReadRepository<Student>>();
    private readonly Mock<IRepository<Student>> _repoMock = new Mock<IRepository<Student>>();

    public StudentServiceTests()
    {
        _studentService = new StudentService(_readRepoMock.Object, _repoMock.Object);
    }

    [Fact]
    public async Task GetStudentByIdAsync_ShouldReturnStudent_WhenStudentExists()
    {
        //Arrange
        const int studentId = 1;

        var studentResult = new Student
        {
            Id = studentId,
            Name = "Test Student",
            Email = "test@mail.com"
        };
        
        _readRepoMock.Setup(x => x.GetByIdAsync(studentId, new CancellationToken())).ReturnsAsync(studentResult);

        //Act
        var studentFound = await _studentService.GetStudentByIdAsync(studentId);

        //Assert
        Assert.Equal(1, studentFound.Id);
        Assert.Equal("Test Student", studentFound.Name);
        Assert.Equal("test@mail.com", studentFound.Email);
    }

    [Fact]
    public async Task GetStudentByIdAsync_ShouldThrowException_WhenStudentDoesntExist()
    {
        //Arrange
        const int studentId = 2;
        
        var studentResult = new Student
        {
            Id = 1,
            Name = "Test Student",
            Email = "test@mail.com"
        };
        
        _readRepoMock.Setup(x => x.GetByIdAsync(1, new CancellationToken())).ReturnsAsync(studentResult);
        
        //Act + Assert
        await Assert.ThrowsAsync<StudentNotFoundException>(() => _studentService.GetStudentByIdAsync(studentId));
    }
}