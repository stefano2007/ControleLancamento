using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UserRemoveCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new
                ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> Handle(UserRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userRepository.GetByIdAsync(request.Id);

            if (account == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _userRepository.RemoveAsync(account);
                return result;
            }
        }
    }
}
