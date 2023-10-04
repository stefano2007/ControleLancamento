using ControleLancamento.Application.UseCases.UserAccounts.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Handlers
{
    public class UserAccountCreateCommandHandler : IRequestHandler<UserAccountCreateCommand, UserAccount>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UserAccountCreateCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }
        public async Task<UserAccount> Handle(UserAccountCreateCommand request,
            CancellationToken cancellationToken)
        {
            var userAccount = new UserAccount(request.AccountId, request.UserId, request.IsUserMain);

            if (userAccount == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _userAccountRepository.CreateAsync(userAccount);
            }
        }
    }
}
