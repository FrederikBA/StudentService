using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Students.Web.Interface.Repositories;

namespace Students.Web.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public readonly StudentContext StudentContext;

    public EfRepository(StudentContext studentContext) : base(studentContext) =>
        this.StudentContext = studentContext;
}

