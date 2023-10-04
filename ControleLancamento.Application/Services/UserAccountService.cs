using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.UserAccounts.Commands;
using ControleLancamento.Application.UseCases.UserAccounts.Queries;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserAccountService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<UserAccountDTO> CreateAsync(UserAccountCreateDTO userAccountDto, int userModification)
        {
            //TODO: Verificar se o usuario userModification tem permissão para criar (exemplo necessario ser o usuario principal)
            var userAccountCreateCommand = _mapper.Map<UserAccountCreateCommand>(userAccountDto);
            var result = await _mediator.Send(userAccountCreateCommand);

            return _mapper.Map<UserAccountDTO>(result);
        }

        public async Task<IEnumerable<UserAccountDTO>> GetUserAccountsByUserIdQuery(int userId)
        {
            var userAccountByIdQuery = new GetUserAccountsByUserIdQuery(userId);

            if (userAccountByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(userAccountByIdQuery);

            return _mapper.Map<IEnumerable<UserAccountDTO>>(result);
        }

        public async Task<UserAccountDTO> GetByIdAndUserIdAsync(int id, int userId)
        {
            var userAccountByIdQuery = new GetUserAccountByIdAndUserIdQuery(id, userId);

            if (userAccountByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(userAccountByIdQuery);

            return _mapper.Map<UserAccountDTO>(result);
        }

        public async Task RemoveAsync(int id, int userId)
        {
            var userRemoveCommand = new UserAccountRemoveCommand(id, userId);
            if (userRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(userRemoveCommand);
        }

        public async Task<UserAccountDTO> UpdateAsync(UserAccountUpdateDTO userAccountDto, int userModification)
        {
            //TODO: Verificar se o usuario userModification tem permissão para modificar (exemplo necessario ser o usuario principal)
            var userAccountUpdateCommand = _mapper.Map<UserAccountUpdateCommand>(userAccountDto);
            var result = await _mediator.Send(userAccountUpdateCommand);

            return _mapper.Map<UserAccountDTO>(result);
        }
    }
}
