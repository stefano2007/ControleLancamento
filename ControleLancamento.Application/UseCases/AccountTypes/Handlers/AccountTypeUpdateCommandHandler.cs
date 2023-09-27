using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class AccountTypeUpdateCommandHandler : IRequestHandler<AccountTypeUpdateCommand, AccountType>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountTypeUpdateCommandHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository ??
            throw new ArgumentNullException(nameof(accountTypeRepository));
        }

        public async Task<AccountType> Handle(AccountTypeUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var accountType = await _accountTypeRepository.GetByIdAsync(request.Id);

            if (accountType == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                accountType.Update(request.Name);

                return await _accountTypeRepository.UpdateAsync(accountType);

            }
        }
    }
}
