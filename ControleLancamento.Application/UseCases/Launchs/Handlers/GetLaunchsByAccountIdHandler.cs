using ControleLancamento.Application.UseCases.Launchs.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Handlers
{
    public class GetLaunchsByAccountIdHandler : IRequestHandler<GetLaunchsByAccountIdQuery, IEnumerable<Launch>>
    {
        private readonly ILaunchRepository _launchRepository;

        public GetLaunchsByAccountIdHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository;
        }

        public async Task<IEnumerable<Launch>> Handle(GetLaunchsByAccountIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _launchRepository.GetLaunchsByAccountIdAsync(request.AccountId);
        }
    }
}
