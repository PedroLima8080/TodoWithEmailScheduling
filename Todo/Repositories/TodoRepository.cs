using Todo.Application.Context;

namespace Todo.Application.Repositories
{
    public class TodoRepository : BaseRepository<Todo.Data.Models.Todo>
    {
        public TodoRepository(DataContext _context) : base(_context) { }

    }
}
