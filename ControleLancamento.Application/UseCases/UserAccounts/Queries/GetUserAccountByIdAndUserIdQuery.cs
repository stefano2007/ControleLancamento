using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Queries
{
    public class GetUserAccountByIdAndUserIdQuery : IRequest<UserAccount>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public GetUserAccountByIdAndUserIdQuery(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
