using ControleLancamento.Application.UseCases.Accounts.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Accounts.Handlers
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<Account>>
    {
        private readonly IAccountRepository _categoryRepository;

        public GetAccountsQueryHandler(IAccountRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Account>> Handle(GetAccountsQuery request,
            CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAccountsAsync();
        }
    }
}
