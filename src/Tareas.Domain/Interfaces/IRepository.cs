using Tareas.Domain.Entities;

namespace Tareas.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
    }
}
