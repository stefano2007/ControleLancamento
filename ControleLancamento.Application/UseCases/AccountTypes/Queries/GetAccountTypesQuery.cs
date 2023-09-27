using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Queries
{
    public class GetAccountTypesQuery : IRequest<IEnumerable<AccountType>>
    {
    }
}
