using Tareas.Domain.Entities;

namespace Tareas.Domain.Interfaces
{
    public interface IWorkUseCase
    {
        Task<string> Create(Work work);
        IEnumerable<Work> GetAll();
        Task<string> Update(Work work);
        Task<string> Delete(int id);
        Task<IEnumerable<Work>> GetbyIdCategory(int idCategory);
    }
}
