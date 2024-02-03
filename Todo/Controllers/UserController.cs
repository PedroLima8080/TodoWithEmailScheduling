using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using Todo.Data.DTOs;
using Todo.Data.Models;

namespace Todo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public User Add(UserDTO dto)
        {
            return _service.Add(new User(dto));
        }

        [HttpPut("{id}")]
        public User Update(int id, UserDTO dto)
        {
            return _service.Update(id, dto);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _service.getAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _service.Find(id);
        }

        [HttpDelete("{id}")]
        public User Remove(int id)
        {
            return _service.Remove(id);
        }
    }
}
