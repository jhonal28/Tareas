using Tareas.Domain.Entities;

namespace Tareas.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> CategoryRepository { get; }

        IWorkRepository WorkRepository { get; }

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
