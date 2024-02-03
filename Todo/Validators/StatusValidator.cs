using FluentValidation;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Todo.Application.Repositories;
using Todo.Application.Services;
using Todo.Data.Models;

namespace Todo.Application.Validators
{
    public class StatusValidator: AbstractValidator<Status>
    {
        public StatusValidator(StatusRepository _repository)
        {
            RuleFor(status => status.Description)
                .NotNull()
                .Must(_repository.IsDescriptionUnique)
                .WithMessage("Duplicated entity");
        }
    }
}
