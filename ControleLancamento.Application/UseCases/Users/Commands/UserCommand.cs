using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Commands
{
    public abstract class UserCommand : IRequest<User>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Occupation { get; private set; }
        public string CellPhone { get; private set; }
    }
}
