using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Entities.Enum;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Commands
{
    public abstract class LaunchCommand : IRequest<Launch>
    {
        public LaunchType LaunchType { get; private set; }
        public int CategoryId { get; private set; }
        public int AccountId { get; private set; }
        public string Description { get; private set; }
        public DateTime DateLaunch { get; private set; }
        public decimal Price { get; private set; }
        public string Observation { get; private set; }
        public string Tag { get; private set; }
    }
}
