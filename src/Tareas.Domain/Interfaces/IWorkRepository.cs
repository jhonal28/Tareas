using Tareas.Domain.Entities;

namespace Tareas.Domain.Interfaces
{
    public interface IWorkRepository : IRepository<Work>
    {
        Task<IEnumerable<Work>> GetByCategory(int idCategory);
    }
}
