using FluentValidation;
using System.Text.Json;
using System.Text;
using Todo.Application.Repositories;
using Todo.Data.DTOs;
using Todo.Messaging;
using RabbitMQ.Client;

namespace Todo.Application.Services
{
    public class TodoService : BaseService<Todo.Data.Models.Todo>
    {
        private MessageService _messageService;
        private UserService _userService;
        private StatusService _statusService;

        public TodoService(TodoRepository repository, UserService userService, StatusService statusService) : base(repository)
        {
            _userService = userService;
            _statusService = statusService;
        }

        //public TodoService(TodoRepository repository, MessageService messageService) : base(repository) {
        //    this._messageService = messageService;
        //}

        protected override AbstractValidator<Todo.Data.Models.Todo> GetAddValidator()
        {
            return new TodoValidator();
        }

        public Todo.Data.Models.Todo Update(int id, TodoDTO newEntityData)
        {
            Todo.Data.Models.Todo entity = Find(id);

            if(newEntityData.Title != null) entity.Title = newEntityData.Title;
            if (newEntityData.Description != null) entity.Description = newEntityData.Description;
            if (newEntityData.AssignedToId != null)
            {
                _userService.Find(newEntityData.AssignedToId.Value);
                entity.AssignedToId = newEntityData.AssignedToId.Value;
            }
            if (newEntityData.StatusId != null)
            {
                _statusService.Find(newEntityData.StatusId.Value);
                entity.StatusId = newEntityData.StatusId;
            }

            return _repository.Update(entity);

        }

        protected override void AfterAdd(Data.Models.Todo createdEntity)
        {
            base.AfterAdd(createdEntity);
            //byte[] body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize("teste"));
            //_messageService.emailChannel.BasicPublish(exchange: "", routingKey: "myQueue", basicProperties: null, body: body);
        }
    }
}
