using Todo.Data.DTOs;

namespace Todo.Data.Models
{
    public class Todo
    {
        public Todo()
        { }

        public Todo(TodoDTO todoDTO)
        {
            this.Title = todoDTO.Title;
            this.Description = todoDTO.Description;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }
        public int? StatusId { get; set; }
        public Status? Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}



