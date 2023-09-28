using ControleLancamento.Application.UseCases.Launchs.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Handlers;
public class LaunchCreateCommandHandler : IRequestHandler<LaunchCreateCommand, Launch>
{
    private readonly ILaunchRepository _launchRepository;
    public LaunchCreateCommandHandler(ILaunchRepository launchRepository)
    {
        _launchRepository = launchRepository;
    }
    public async Task<Launch> Handle(LaunchCreateCommand request,
        CancellationToken cancellationToken)
    {
        var launch = new Launch(request.LaunchType, request.CategoryId, request.AccountId, request.Description, request.DateLaunch, request.Price, request.Observation, request.Tag);

        if (launch == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _launchRepository.CreateAsync(launch);
        }
    }
}
