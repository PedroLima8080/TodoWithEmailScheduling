using FluentValidation;
using Todo.Application.Repositories;
using Todo.Data.Models;

namespace Todo.Application.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator(UserRepository _repository)
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .Must(_repository.IsEmailUnique)
                .WithMessage("Email must be unique");
        }
    }
}
