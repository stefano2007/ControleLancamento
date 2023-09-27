using ControleLancamento.Application.UseCases.AccountTypes.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Handlers
{
    public class GetAccountTypeByIdQueryHandler : IRequestHandler<GetAccountTypeByIdQuery, AccountType>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public GetAccountTypeByIdQueryHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<AccountType> Handle(GetAccountTypeByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _accountTypeRepository.GetByIdAsync(request.Id);
        }
    }
}
