using EmailScheduling.Context;
using EmailScheduling.Exceptions;
using EmailScheduling.Models;

namespace EmailScheduling.Repositories
{
    public class TodoRepository
    {
        private DataContext _context;

        public TodoRepository(DataContext _context)
        {
            this._context = _context;
        }

        public Todo Add(Todo todo)
        {
            Todo entity = this._context.Set<Todo>().Add(todo).Entity;
            this._context.SaveChanges();
            return entity;
        }
        public List<Todo> All()
        {
            return this._context.Set<Todo>().ToList();
        }

        public Todo Remove(int id)
        {
            Todo entity = this._context.Set<Todo>().Find(id);

            if (entity == null)
                throw new EntityNotFoundException();
                
            this._context.Set<Todo>().Remove(entity);
            this._context.SaveChanges();

            return entity;
        }

    }
}
