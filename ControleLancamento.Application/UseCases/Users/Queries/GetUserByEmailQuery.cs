using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
