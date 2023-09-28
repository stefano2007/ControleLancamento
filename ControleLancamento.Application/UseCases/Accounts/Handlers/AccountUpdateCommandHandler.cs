using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Accounts.Handlers
{
    public class AccountUpdateCommandHandler : IRequestHandler<AccountUpdateCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountUpdateCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ??
            throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Account> Handle(AccountUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                account.Update(request.AccountTypeId, request.Name);

                return await _accountRepository.UpdateAsync(account);

            }
        }
    }
}
