using ControleLancamento.Application.UseCases.Launchs.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Handlers
{
    public class LaunchRemoveCommandHandler : IRequestHandler<LaunchRemoveCommand, Launch>
    {
        private readonly ILaunchRepository _launchRepository;
        public LaunchRemoveCommandHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository ?? throw new
                ArgumentNullException(nameof(launchRepository));
        }

        public async Task<Launch> Handle(LaunchRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var launch = await _launchRepository.GetByIdAsync(request.Id);

            if (launch == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _launchRepository.RemoveAsync(launch);
                return result;
            }
        }
    }
}
