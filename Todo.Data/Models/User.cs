using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DTOs;

namespace Todo.Data.Models
{
    public class User
    {
        public User()
        {
            
        }

        public User(UserDTO dto)
        {
            Name = dto.Name;
            Email = dto.Email;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
