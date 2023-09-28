using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Queries
{
    public class GetLaunchsByAccountIdQuery : IRequest<IEnumerable<Launch>>
    {
        public int AccountId { get; set; }
        public GetLaunchsByAccountIdQuery(int accountId)
        {
            AccountId = accountId;
        }
    }
}
