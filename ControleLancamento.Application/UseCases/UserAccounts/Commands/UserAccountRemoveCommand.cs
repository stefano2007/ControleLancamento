using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Commands
{
    public class UserAccountRemoveCommand : IRequest<UserAccount>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserAccountRemoveCommand(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
