

using EmailScheduling.Exceptions;
using EmailScheduling.Models;
using EmailScheduling.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace EmailScheduling.Services
{
    public class TodoService: BaseService<Todo>
    {
        public TodoService(TodoRepository repository): base(repository) { }

        protected override AbstractValidator<Todo> GetAddValidator()
        {
            return new TodoValidator();
        }

        protected override void BeforeAdd(Todo entity)
        {
            base.BeforeAdd(entity);
            entity.Description = entity.Description.ToUpper();
        }

    }
}
