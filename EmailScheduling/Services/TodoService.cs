

using EmailScheduling.Exceptions;
using EmailScheduling.Models;
using EmailScheduling.Repositories;
using FluentValidation.Results;

namespace EmailScheduling.Services
{
    public class TodoService
    {
        private TodoRepository _repository;

        public TodoService(TodoRepository repository)
        {
            this._repository = repository;
        }

        public Todo Add(Todo todo)
        {
            ValidationResult validationResult = new TodoValidator().Validate(todo);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            return this._repository.Add(todo);
        }

        public List<Todo> All()
        {
            return this._repository.All();
        }

        public Todo Remove(int id)
        {
            return this._repository.Remove(id);
        }

    }
}
