using EmailScheduling.Context;
using EmailScheduling.Exceptions;
using EmailScheduling.Models;

namespace EmailScheduling.Repositories
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
            T newEntity = this._context.Set<T>().Add(entity).Entity;
            this._context.SaveChanges();
            return newEntity;
        }

        public List<T> All()
        {
            return this._context.Set<T>().ToList();
        }

        public T Remove(int id)
        {
            T entity = this.Find(id);

            return entity;
        }

        public T Find(int id)
        {
            T entity = this._context.Set<T>().Find(id);

            if (entity == null)
                throw new EntityNotFoundException();

            return entity;
        }
    }
}
