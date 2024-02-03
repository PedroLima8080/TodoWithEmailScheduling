using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data.DTOs
{
    public class TodoDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToId { get; set; }
        public int? StatusId { get; set; }

    }
}
