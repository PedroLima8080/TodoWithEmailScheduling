using FluentValidation;
using Todo.Application.Repositories;
using Todo.Data.DTOs;
using Todo.Messaging;

namespace Todo.Application.Services
{
    public class TodoService : BaseService<Todo.Data.Models.Todo>
    {
        public TodoService(TodoRepository repository, MessageService messageService) : base(repository, messageService) { }

        protected override AbstractValidator<Todo.Data.Models.Todo> GetAddValidator()
        {
            return new TodoValidator();
        }

        public Todo.Data.Models.Todo Update(int id, TodoDTO newEntityData)
        {
            Todo.Data.Models.Todo entity = Find(id);

            if(newEntityData.Title != null) entity.Title = newEntityData.Title;
            if (newEntityData.Description != null) entity.Description = newEntityData.Description;

            return _repository.Update(entity);

        }
    }
}
