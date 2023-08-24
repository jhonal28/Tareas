using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tareas.API.Response;
using Tareas.Domain.DTOs;
using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;
using Tareas.Domain.UseCase;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class WorkController : ControllerBase
    {
        private readonly IWorkUseCase _workUseCase;
        private readonly IMapper _mapper;

        public WorkController(IWorkUseCase workUseCase,
            IMapper mapper)
        {
            _workUseCase = workUseCase;
            _mapper = mapper;            
        }

        [HttpPost]
        public async Task<IActionResult> Post(WorkDto workDto)
        {
            try
            {
                var value = _mapper.Map<Work>(workDto);
                var response = await _workUseCase.Create(value);
                var result = BaseResponse<Work>.Build(value, response);
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
                var works = _workUseCase.GetAll();
                return await Task.FromResult(Ok(_mapper.Map<IEnumerable<WorkDto>>(works)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, WorkDto workDto)
        {
            try
            {
                var work = _mapper.Map<Work>(workDto);
                work.Id = id;

                var response = await _workUseCase.Update(work);
                var result = BaseResponse<Work>.Build(work, response);
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
                var result = await _workUseCase.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }



        [HttpGet("{idCategory}")]
        public async Task<IActionResult> GetbyIdCategory(int idCategory)
        {
            try
            {
                var works = await _workUseCase.GetbyIdCategory(idCategory);
                return await Task.FromResult(Ok(_mapper.Map<IEnumerable<WorkDto>>(works)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }

        }
    }
}
