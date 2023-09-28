using ControleLancamento.Application.UseCases.Launchs.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Handlers
{
    public class GetLaunchByIdQueryHandler : IRequestHandler<GetLaunchByIdQuery, Launch>
    {
        private readonly ILaunchRepository _launchRepository;
        public GetLaunchByIdQueryHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository;
        }

        public async Task<Launch> Handle(GetLaunchByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _launchRepository.GetByIdAsync(request.Id);
        }
    }
}
