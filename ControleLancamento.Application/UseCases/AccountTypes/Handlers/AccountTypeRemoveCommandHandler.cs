using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class AccountTypeRemoveCommandHandler : IRequestHandler<AccountTypeRemoveCommand, AccountType>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountTypeRemoveCommandHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository ?? throw new
                ArgumentNullException(nameof(accountTypeRepository));
        }

        public async Task<AccountType> Handle(AccountTypeRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _accountTypeRepository.GetByIdAsync(request.Id);

            if (account == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _accountTypeRepository.RemoveAsync(account);
                return result;
            }
        }
    }
}
