using ControleLancamento.Application.UseCases.Launchs.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Handlers
{
    public class LaunchUpdateCommandHandler : IRequestHandler<LaunchUpdateCommand, Launch>
    {
        private readonly ILaunchRepository _launchRepository;
        public LaunchUpdateCommandHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository ??
            throw new ArgumentNullException(nameof(launchRepository));
        }

        public async Task<Launch> Handle(LaunchUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var launch = await _launchRepository.GetByIdAsync(request.Id);

            if (launch == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                launch.Update(request.LaunchType, request.CategoryId, request.AccountId, request.Description, request.DateLaunch, request.Price, request.Observation, request.Tag);

                return await _launchRepository.UpdateAsync(launch);

            }
        }
    }
}
