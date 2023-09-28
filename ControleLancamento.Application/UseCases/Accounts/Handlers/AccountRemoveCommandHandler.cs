using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class AccountRemoveCommandHandler : IRequestHandler<AccountRemoveCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountRemoveCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new
                ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Account> Handle(AccountRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _accountRepository.RemoveAsync(account);
                return result;
            }
        }
    }
}
