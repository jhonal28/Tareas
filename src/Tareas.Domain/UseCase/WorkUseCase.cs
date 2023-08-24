using Tareas.Domain.Entities;
using Tareas.Domain.Exceptions;
using Tareas.Domain.Interfaces;

namespace Tareas.Domain.UseCase
{
    public class WorkUseCase : IWorkUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string successfulMessage = "Tarea creada o actualizada exitosamente!";
        private const string errorMessage = "No fue posible crear o actuaizar la tarea";
        private const string noFoundMessage = "No existe la tarea";
        private const string deleteMessage = "Tarea eliminada exitosamente!";

        public WorkUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Create(Work work)
        {
            await _unitOfWork.WorkRepository.Add(work);
            var response = await _unitOfWork.SaveChangesAsync();
            if (response == 0)
            {
                throw new BusinessException(errorMessage);
            }
            return successfulMessage;
        }

        public IEnumerable<Work> GetAll()
        {
            return _unitOfWork.WorkRepository.GetAll();
        }

        public async Task<string> Update(Work work)
        {
            var value = await _unitOfWork.WorkRepository.GetById(work.Id) ?? throw new BusinessException(noFoundMessage);

            value.IdCategory = work.IdCategory;
            value.Description = work.Description;
            value.Complete = work.Complete;

            _unitOfWork.WorkRepository.Update(value);
            var response = await _unitOfWork.SaveChangesAsync();
            if (response == 0)
            {
                throw new BusinessException(errorMessage);
            }
            return successfulMessage;
        }

        public async Task<string> Delete(int id)
        {
            await _unitOfWork.WorkRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return deleteMessage;
        }

        public async Task<IEnumerable<Work>> GetbyIdCategory(int idCategory)
        {
            return await _unitOfWork.WorkRepository.GetByCategory(idCategory);
        }
    }
}
