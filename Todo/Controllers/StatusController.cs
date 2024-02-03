using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using Todo.Data.DTOs;

namespace Todo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private StatusService _service;
        public StatusController(StatusService service) {
            _service = service;
        }

        [HttpPost()]
        public ActionResult Add(StatusDTO statusDTO) {
            return Ok(_service.Add(new Data.Models.Status(statusDTO)));
        }

        [HttpGet()]
        public List<Todo.Data.Models.Status> getAll() {
            return _service.getAll();
        }

        [HttpGet("{id}")]
        public Todo.Data.Models.Status get(int id)
        {
            return _service.Find(id);
        }

        [HttpDelete("{id}")]
        public Todo.Data.Models.Status delete(int id)
        {
            return _service.Remove(id);
        }
    }
}
