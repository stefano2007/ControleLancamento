using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Commands
{
    public class AccountTypeRemoveCommand : IRequest<AccountType>
    {
        public int Id { get; set; }
        public AccountTypeRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
