using Ardalis.Specification;

namespace Students.Web.Interface.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
    
}