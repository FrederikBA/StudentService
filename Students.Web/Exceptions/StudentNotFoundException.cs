namespace Students.Web.Exceptions;

public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(int id) : base($"Student with id {id} was not found.")
    {
    }
}