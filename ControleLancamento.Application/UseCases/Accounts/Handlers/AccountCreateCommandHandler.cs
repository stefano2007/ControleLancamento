using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers;
public class AccountCreateCommandHandler : IRequestHandler<AccountCreateCommand, Account>
{
    private readonly IAccountRepository _accountRepository;
    public AccountCreateCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<Account> Handle(AccountCreateCommand request,
        CancellationToken cancellationToken)
    {
        var account = new Account(request.AccountTypeId, request.Name);

        if (account == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _accountRepository.CreateAsync(account);
        }
    }
}
