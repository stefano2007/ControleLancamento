using ControleLancamento.Application.UseCases.UserAccounts.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Handlers
{
    public class GetUserAccountByIdAndUserIdQueryHandler : IRequestHandler<GetUserAccountByIdAndUserIdQuery, UserAccount>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public GetUserAccountByIdAndUserIdQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccount> Handle(GetUserAccountByIdAndUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userAccountRepository.GetByIdAndUserIdAsync(request.Id, request.UserId);
        }
    }
}
