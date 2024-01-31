using Todo.Application.Context;

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

        public T Update(T entity)
        {
            T updatedEntity = _context.Set<T>().Update(entity).Entity;
            _context.SaveChanges();
            return updatedEntity;
        }
        public List<T> All()
        {
            return _context.Set<T>().ToList();
        }

        public T Remove(int id)
        {
            T removedEntity = Find(id);
            _context.Set<T>().Remove(removedEntity);
            _context.SaveChanges();
            return removedEntity;
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
