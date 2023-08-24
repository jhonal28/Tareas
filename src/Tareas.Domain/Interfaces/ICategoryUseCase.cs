using Tareas.Domain.Entities;

namespace Tareas.Domain.Interfaces
{
    public interface ICategoryUseCase
    {
        Task<string> Create(Category category);
        IEnumerable<Category> GetAll();
        Task<string> Update(Category category);
        Task<string> Delete(int id);
        Task<Category> GetById(int id);
    }
}
