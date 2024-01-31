using FluentValidation.Results;

namespace Todo.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationFailure> errors;
        public ValidationException(List<ValidationFailure> errors)
        {
            this.errors = errors;
        }
    }
}
