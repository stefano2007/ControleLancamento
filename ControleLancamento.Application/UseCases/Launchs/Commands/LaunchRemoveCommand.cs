using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Commands
{
    public class LaunchRemoveCommand : IRequest<Launch>
    {
        public int Id { get; set; }
        public LaunchRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
