using FluentValidation;
using Todo.Application.Repositories;
using Todo.Application.Validators;

namespace Todo.Application.Services
{
    public class StatusService: BaseService<Todo.Data.Models.Status>
    {
        public StatusService(StatusRepository _repository): base(_repository) { }

        protected override AbstractValidator<Todo.Data.Models.Status> GetAddValidator()
        {
            return new StatusValidator((StatusRepository) this._repository);
        }

    }
}
