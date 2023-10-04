using ControleLancamento.Application.UseCases.UserAccounts.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Handlers
{
    public class UserAccountRemoveCommandHandler : IRequestHandler<UserAccountRemoveCommand, UserAccount>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UserAccountRemoveCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository ?? throw new
                ArgumentNullException(nameof(userAccountRepository));
        }

        public async Task<UserAccount> Handle(UserAccountRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetByIdAndUserIdAsync(request.Id, request.UserId);

            if (userAccount == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _userAccountRepository.RemoveAsync(userAccount);
                return result;
            }
        }
    }
}
