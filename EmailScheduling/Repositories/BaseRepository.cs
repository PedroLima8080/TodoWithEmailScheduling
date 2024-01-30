using Todo.Application.Context;
using Todo.Application.Exceptions;

namespace Todo.Application.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private DataContext _context;

        public BaseRepository(DataContext _context)
        {
            this._context = _context;
        }

        public T Add(T entity)
        {
            T newEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return newEntity;
        }

        public List<T> All()
        {
            return _context.Set<T>().ToList();
        }

        public T Remove(int id)
        {
            T entity = Find(id);

            return entity;
        }

        public T Find(int id)
        {
            T entity = _context.Set<T>().Find(id);

            if (entity == null)
                throw new EntityNotFoundException();

            return entity;
        }
    }
}
