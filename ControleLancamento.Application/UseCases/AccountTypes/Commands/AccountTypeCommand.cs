using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Commands
{
    public abstract class AccountTypeCommand : IRequest<AccountType>
    {
        public string Name { get; private set; }
    }
}
