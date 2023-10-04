using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.UserAccounts.Commands
{
    public class UserAccountCommand : IRequest<UserAccount>
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public bool IsUserMain { get; set; }
    }
}
