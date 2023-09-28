using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Commands
{
    public abstract class AccountCommand : IRequest<Account>
    {
        public int AccountTypeId { get; private set; }
        public string Name { get; private set; }
        public string Color { get; private set; }
        public string Icon { get; private set; }
    }
}
