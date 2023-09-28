using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Commands
{
    public class AccountRemoveCommand : IRequest<Account>
    {
        public int Id { get; set; }
        public AccountRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
