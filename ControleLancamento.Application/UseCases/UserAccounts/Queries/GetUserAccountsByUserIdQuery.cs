using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Queries
{
    public class GetUserAccountsByUserIdQuery : IRequest<IEnumerable<UserAccount>>
    {
        public int UserId { get; set; }
        public GetUserAccountsByUserIdQuery(int userid)
        {
            UserId = userid;
        }
    }
}
