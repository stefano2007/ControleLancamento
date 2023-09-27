using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
