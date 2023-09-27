using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Handlers;
public class AccountTypeCreateCommandHandler : IRequestHandler<AccountTypeCreateCommand, AccountType>
{
    private readonly IAccountTypeRepository _accountTypeRepository;
    public AccountTypeCreateCommandHandler(IAccountTypeRepository accountTypeRepository)
    {
        _accountTypeRepository = accountTypeRepository;
    }
    public async Task<AccountType> Handle(AccountTypeCreateCommand request,
        CancellationToken cancellationToken)
    {
        var account = new AccountType(request.Name);

        if (account == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _accountTypeRepository.CreateAsync(account);
        }
    }
}
