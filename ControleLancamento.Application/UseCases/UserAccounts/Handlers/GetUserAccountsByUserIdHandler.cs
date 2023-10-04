using ControleLancamento.Application.UseCases.UserAccounts.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Handlers
{
    public class GetUserAccountsByUserIdHandler : IRequestHandler<GetUserAccountsByUserIdQuery, IEnumerable<UserAccount>>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserAccountsByUserIdHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }
        public async Task<IEnumerable<UserAccount>> Handle(GetUserAccountsByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _userAccountRepository.GetUserAccountsAsync(request.UserId);
        }
    }
}
