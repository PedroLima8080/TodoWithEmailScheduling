using EmailScheduling.Models;
using EmailScheduling.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailScheduling.Controllers
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
        public IActionResult Post(Todo todo)
        {
            return Ok(this._service.Add(todo));
        }

        [HttpGet]
        public List<Todo> All() {
            return this._service.All(); ;
        }

        [HttpDelete]
        public Todo Remove(int id)
        {
            return this._service.Remove(id); ;
        }
    }
}
