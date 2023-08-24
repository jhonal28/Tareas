using AutoMapper;
using Tareas.Domain.DTOs;
using Tareas.Domain.Entities;

namespace Tareas.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Work, WorkDto>().ReverseMap();
        }
    }
}
