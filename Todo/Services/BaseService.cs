using FluentValidation;
using FluentValidation.Results;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;
using System.Threading.Channels;
using Todo.Application.Exceptions;
using Todo.Application.Repositories;
using Todo.Messaging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CustomValidationException = Todo.Application.Exceptions.ValidationException;
using RabbitMQ.Client;
using System.Reflection;

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

        public List<T> getAll()
        {
            return _repository.getAll();
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
