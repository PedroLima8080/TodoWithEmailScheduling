using FluentValidation;
using FluentValidation.Results;
using Todo.Application.Exceptions;
using Todo.Application.Repositories;
using CustomValidationException = Todo.Application.Exceptions.ValidationException;

namespace Todo.Application.Services
{
    public abstract class BaseService<T> where T : class
    {
        protected BaseRepository<T> _repository;

        protected virtual AbstractValidator<T> GetAddValidator()
        {
            return null;
        }

        protected virtual void BeforeAdd(T entity)
        { }

        protected virtual void AfterAdd(T createdEntity)
        { }

        public BaseService(BaseRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            AbstractValidator<T> validator = GetAddValidator();

            if (validator != null)
            {
                ValidationResult validationResult = validator.Validate(entity);

                if (!validationResult.IsValid)
                    throw new CustomValidationException(validationResult.Errors);
            }

            BeforeAdd(entity);
            T createdEntity = _repository.Add(entity);
            AfterAdd(entity);

            return createdEntity;
        }

        public List<T> All()
        {
            return _repository.All();
        }

        public T Find(int id)
        {
            return _repository.Find(id) ?? throw new EntityNotFoundException();
        }

        public T Remove(int id)
        {
            T entity = Find(id);
            return _repository.Remove(id);
        }
    }
}
