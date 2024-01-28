using EmailScheduling.Context;
using EmailScheduling.Exceptions;
using EmailScheduling.Models;

namespace EmailScheduling.Repositories
{
    public class TodoRepository: BaseRepository<Todo>
    {
        public TodoRepository(DataContext _context): base(_context) { }

    }
}
