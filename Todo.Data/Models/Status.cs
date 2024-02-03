using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DTOs;

namespace Todo.Data.Models
{
    public class Status
    {
        public Status()
        { }

        public Status(StatusDTO _dto)
        {
            this.Description = _dto.Description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
