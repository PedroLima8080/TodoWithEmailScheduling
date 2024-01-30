using FluentValidation;
using Todo.Application.Repositories;

namespace Todo.Application.Services
{
    public class TodoService : BaseService<Todo.Data.Models.Todo>
    {
        public TodoService(TodoRepository repository) : base(repository) { }

        protected override AbstractValidator<Todo.Data.Models.Todo> GetAddValidator()
        {
            return new TodoValidator();
        }

        protected override void BeforeAdd(Todo.Data.Models.Todo entity)
        {
            base.BeforeAdd(entity);
            entity.Description = entity.Description.ToUpper();
        }

    }
}
