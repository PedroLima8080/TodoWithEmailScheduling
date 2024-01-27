using FluentValidation.Results;

namespace EmailScheduling.Exceptions
{
    public class ValidationException: Exception
    {
        public List<ValidationFailure> errors;
        public ValidationException(List<ValidationFailure> errors) {
            this.errors = errors;
        }
    }
}
