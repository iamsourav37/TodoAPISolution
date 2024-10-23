using AutoMapper;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTOs.TodoDtos;

namespace TodoAPI.Utility
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Todo, TodoDTO>().ReverseMap();
            CreateMap<Todo, CreateTodoDTO>().ReverseMap();
            CreateMap<Todo, UpdateTodoDTO>().ReverseMap();
        }
    }
}
