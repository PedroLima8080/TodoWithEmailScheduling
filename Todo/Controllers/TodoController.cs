using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;

namespace Todo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoService _service;

        public TodoController(TodoService _service)
        {
            this._service = _service;
        }

        [HttpPost]
        public IActionResult Post(Todo.Data.DTOs.TodoDTO todoDTO)
        {
            return Ok(_service.Add(new Data.Models.Todo(todoDTO)));
        }

        [HttpGet]
        public List<Todo.Data.Models.Todo> All()
        {
            return _service.All();
        }

        [HttpGet("{id}")]
        public Todo.Data.Models.Todo Find(int id)
        {
            return _service.Find(id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo.Data.DTOs.TodoDTO todoDTO)
        {
            return Ok(_service.Update(id, todoDTO));
        }

        [HttpDelete]
        public Todo.Data.Models.Todo Remove(int id)
        {
            return _service.Remove(id);
        }
    }
}
