

using EmailScheduling.Repositories;
using FluentValidation;
using FluentValidation.Results;
using CustomValidationException = EmailScheduling.Exceptions.ValidationException;

namespace EmailScheduling.Services
{
    public abstract class BaseService<T> where T : class
    {
        private BaseRepository<T> _repository;

        protected virtual AbstractValidator<T> GetAddValidator()
        {
            return null;
        }

        protected virtual void BeforeAdd(T entity)
        { }

        protected virtual void AfterAdd(T createdEntity)
        { }

        public BaseService(BaseRepository<T> repository)
        {
            this._repository = repository;
        }

        public T Add(T entity)
        {
            AbstractValidator<T> validator = GetAddValidator();

            if(validator != null)
            {
                ValidationResult validationResult = validator.Validate(entity);

                if (!validationResult.IsValid)
                    throw new CustomValidationException(validationResult.Errors);
            }

            BeforeAdd(entity);
            T createdEntity = this._repository.Add(entity);
            AfterAdd(entity);

            return createdEntity;
        }

        public List<T> All()
        {
            return this._repository.All();
        }

        public T Find(int id)
        {
            return this._repository.Find(id);
        }

        public T Remove(int id)
        {
            return this._repository.Remove(id);
        }
    }
}
