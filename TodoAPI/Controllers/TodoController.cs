using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTOs.TodoDtos;
using TodoAPI.Repository.Interface;
using TodoAPI.Utility;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository todoRepository, IMapper mapper)
        {
            this._todoRepository = todoRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTodo()
        {
            ApiResponse<List<TodoDTO>> apiResponse = new();
            var allTodos = await _todoRepository.GetAllTodoAsync();

            var todoDtoList = _mapper.Map<List<TodoDTO>>(allTodos);
            apiResponse.StatusCode = 200;
            apiResponse.Data = todoDtoList;
            return Ok(apiResponse);
        }


        [HttpGet("{todoId}")]
        public async Task<IActionResult> GetTodoById(Guid todoId)
        {
            var todo = await _todoRepository.GetTodoByIdAsync(todoId);

            ApiResponse<TodoDTO> apiResponse = new();

            if (todo == null)
            {
                apiResponse.StatusCode = 404;
                apiResponse.Errors = [$"Id not found '{todoId}'"];
                return BadRequest(apiResponse);
            }
            var todoDto = _mapper.Map<TodoDTO>(todo);
            apiResponse.Data = todoDto;
            apiResponse.StatusCode = 200;

            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoDTO createTodoDTO)
        {
            ApiResponse<TodoDTO> apiResponse = new();
            if (!ModelState.IsValid)
            {
                apiResponse.StatusCode = 429;
                apiResponse.Errors = ModelState.Values.SelectMany(v => v.Errors)
                                 .Select(e => e.ErrorMessage).ToArray();
                return UnprocessableEntity(apiResponse);
            }

            var todo = _mapper.Map<Todo>(createTodoDTO);
            todo.CreatedAt = DateTime.Now;
            todo.UpdatedAt = DateTime.Now;
            await _todoRepository.CreateTodoAsync(todo);
            apiResponse.StatusCode = 201;
            apiResponse.Data = _mapper.Map<TodoDTO>(todo);
            return CreatedAtAction(nameof(GetTodoById), new { todoId = todo.Id }, apiResponse);
        }
    }
}
