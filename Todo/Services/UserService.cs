using FluentValidation;
using Todo.Application.Repositories;
using Todo.Application.Validators;
using Todo.Data.DTOs;
using Todo.Data.Models;

namespace Todo.Application.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(UserRepository repository) : base(repository)
        {
        }

        protected override AbstractValidator<User> GetAddValidator()
        {
            return new UserValidator((UserRepository) _repository);
        }

        public User Update(int id, UserDTO dto)
        {
            User user = Find(id);

            if(dto.Name != null) user.Name = dto.Name;
            if(dto.Email != null) user.Email = dto.Email;

            return _repository.Update(user);
        }
    }
}
