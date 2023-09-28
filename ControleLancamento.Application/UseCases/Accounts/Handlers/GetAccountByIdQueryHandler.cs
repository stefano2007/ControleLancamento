using ControleLancamento.Application.UseCases.Accounts.Queries;
using ControleLancamento.Application.UseCases.Categories.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(GetAccountByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _accountRepository.GetByIdAsync(request.Id);
        }
    }
}
