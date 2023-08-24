using Tareas.Domain.Entities;
using Tareas.Domain.Exceptions;
using Tareas.Domain.Interfaces;

namespace Tareas.Domain.UseCase
{
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string successfulMessage = "Categoría creada o actualizada exitosamente!";
        private const string errorMessage = "No fue posible crear o actuaizar la categoría";
        private const string noFoundMessage = "No existe la categoría";
        private const string deleteMessage = "Categoría eliminada exitosamente!";

        public CategoryUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Create(Category category)
        {
            await _unitOfWork.CategoryRepository.Add(category);
            var response = await _unitOfWork.SaveChangesAsync();
            if (response == 0)
            {
                throw new BusinessException(errorMessage);
            }
            return successfulMessage;
        }

        public  IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public async Task<string> Update(Category category)
        {
            var value = await _unitOfWork.CategoryRepository.GetById(category.Id) ?? throw new BusinessException(noFoundMessage);

            value.Description = category.Description;
            _unitOfWork.CategoryRepository.Update(value);
            var response = await _unitOfWork.SaveChangesAsync();
            if (response == 0)
            {
                throw new BusinessException(errorMessage);
            }
            return successfulMessage;
        }

        public async Task<string> Delete(int id)
        {
            await _unitOfWork.CategoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return deleteMessage;
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }
    }
}
