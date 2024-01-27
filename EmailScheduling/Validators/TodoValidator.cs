using EmailScheduling.Models;
using FluentValidation;

public class TodoValidator : AbstractValidator<Todo>
{
    public TodoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(25).WithMessage("Title cannot exced 25 length");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(50).WithMessage("Title cannot exced 25 length");
    }
}