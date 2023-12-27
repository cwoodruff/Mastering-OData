using odataapimodels.Domain.Entities;
using odataapimodels.Domain.Extensions;

namespace odataapimodels.Domain.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<bool> EntityExists(int? id);
    Task<T> GetAll(int pageNumber, int pageSize);
    Task<T?> GetById(int? id);
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
}