using ControleLancamento.Application.UseCases.AccountTypes.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class GetAccountTypesQueryHandler : IRequestHandler<GetAccountTypesQuery, IEnumerable<AccountType>>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<IEnumerable<AccountType>> Handle(GetAccountTypesQuery request,
            CancellationToken cancellationToken)
        {
            return await _accountTypeRepository.GetAccountTypesAsync();
        }
    }
}
