

using Domain.Entities;

namespace DAL.Repositories
{
    public interface IBaseRepository<T>

    {
        IQueryable<T>? GetAll();

        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);

        T? Get(int id);

        Task<T> Update(T entity);

        IQueryable<Mission> GetTasks(int id);
    }
}
