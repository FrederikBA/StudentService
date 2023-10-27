using Ardalis.Specification;

namespace Students.Web.Interface.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    
}