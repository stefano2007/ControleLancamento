using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.Launchs.Commands;
using ControleLancamento.Application.UseCases.Launchs.Queries;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class LaunchService : ILaunchService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public LaunchService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<LaunchDTO>> GetLaunchsByAccountIdAsync(int accountId)
        {
            var launchsQuery = new GetLaunchsByAccountIdQuery(accountId);

            if (launchsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(launchsQuery);

            return _mapper.Map<IEnumerable<LaunchDTO>>(result);
        }
        public async Task<LaunchDTO> GetByIdAsync(int? id)
        {
            var launchByIdQuery = new GetLaunchByIdQuery(id.Value);

            if (launchByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(launchByIdQuery);

            return _mapper.Map<LaunchDTO>(result);
        }
        public async Task<LaunchDTO> CreateAsync(LaunchCreateDTO launchDto)
        {
            var launchCreateCommand = _mapper.Map<LaunchCreateCommand>(launchDto);
            var result = await _mediator.Send(launchCreateCommand);

            return _mapper.Map<LaunchDTO>(result);
        }
        public async Task<LaunchDTO> UpdateAsync(LaunchUpdateDTO launchDto)
        {
            var launchUpdateCommand = _mapper.Map<LaunchUpdateCommand>(launchDto);
            var result = await _mediator.Send(launchUpdateCommand);

            return _mapper.Map<LaunchDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var launchRemoveCommand = new LaunchRemoveCommand(id.Value);
            if (launchRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(launchRemoveCommand);
        }

    }
}
