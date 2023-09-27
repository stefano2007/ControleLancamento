using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Commands
{
    public class UserRemoveCommand : IRequest<User>
    {
        public int Id { get; set; }
        public UserRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
