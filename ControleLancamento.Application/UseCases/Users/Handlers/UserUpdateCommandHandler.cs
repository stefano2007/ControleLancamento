using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UserUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> Handle(UserUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                user.Update(request.Name, request.Email, request.Password, request.Occupation, request.CellPhone);

                return await _userRepository.UpdateAsync(user);

            }
        }
    }
}
