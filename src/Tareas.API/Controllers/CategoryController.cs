using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Tareas.API.Response;
using Tareas.Domain.DTOs;
using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryUseCase categoryUseCase,
            IMapper mapper)
        {
            _categoryUseCase = categoryUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto categoryDto)
        {
            try
            {
                var value = _mapper.Map<Category>(categoryDto);
                var response = await _categoryUseCase.Create(value);
                var result = BaseResponse<Category>.Build(value, response);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = _categoryUseCase.GetAll();
                return await Task.FromResult(Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                category.Id = id;
                
                var response = await _categoryUseCase.Update(category);
                var result = BaseResponse<Category>.Build(category, response);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _categoryUseCase.Delete(id);
                return Ok(BaseResponse<int>.Build(id, result));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _categoryUseCase.GetById(id);
                return Ok(_mapper.Map<CategoryDto>(result));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }
    }
}
