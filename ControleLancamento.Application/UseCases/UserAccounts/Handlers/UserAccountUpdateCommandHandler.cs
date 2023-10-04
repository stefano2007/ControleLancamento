using ControleLancamento.Application.UseCases.UserAccounts.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Handlers
{
    public class UserAccountUpdateCommandHandler : IRequestHandler<UserAccountUpdateCommand, UserAccount>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UserAccountUpdateCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository ??
            throw new ArgumentNullException(nameof(userAccountRepository));
        }

        public async Task<UserAccount> Handle(UserAccountUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetByIdAndUserIdAsync(request.Id, request.UserId);

            if (userAccount == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                userAccount.Update(request.AccountId, request.UserId, request.IsUserMain);

                return await _userAccountRepository.UpdateAsync(userAccount);
            }
        }
    }
}
