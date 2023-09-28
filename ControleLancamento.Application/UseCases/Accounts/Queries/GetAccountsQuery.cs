using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Accounts.Queries
{
    public class GetAccountsQuery : IRequest<IEnumerable<Account>>
    {
    }
}
