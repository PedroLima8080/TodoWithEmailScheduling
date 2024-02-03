using Microsoft.EntityFrameworkCore;
using Todo.Application.Context;
using Todo.Data.Models;

namespace Todo.Application.Repositories
{
    public class StatusRepository: BaseRepository<Status>
    {
        public StatusRepository(DataContext _context): base(_context)
        { }

        public bool IsDescriptionUnique(string description)
        {
            return !_context.Set<Status>().Any(status => status.Description == description);
        }
    }
}
