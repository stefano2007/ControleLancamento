using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.Accounts.Queries;
using ControleLancamento.Application.UseCases.Categories.Commands;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AccountService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync()
        {
            var accountsQuery = new GetAccountsQuery();

            if (accountsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(accountsQuery);

            return _mapper.Map<IEnumerable<AccountDTO>>(result);
        }
        public async Task<AccountDTO> GetByIdAsync(int? id)
        {
            var accountByIdQuery = new GetAccountByIdQuery(id.Value);

            if (accountByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(accountByIdQuery);

            return _mapper.Map<AccountDTO>(result);
        }
        public async Task<AccountDTO> CreateAsync(AccountCreateDTO accountDto)
        {
            var accountCreateCommand = _mapper.Map<AccountCreateCommand>(accountDto);
            var result = await _mediator.Send(accountCreateCommand);

            return _mapper.Map<AccountDTO>(result);
        }
        public async Task<AccountDTO> UpdateAsync(AccountUpdateDTO accountDto)
        {
            var accountUpdateCommand = _mapper.Map<AccountUpdateCommand>(accountDto);
            var result = await _mediator.Send(accountUpdateCommand);

            return _mapper.Map<AccountDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var accountRemoveCommand = new AccountRemoveCommand(id.Value);
            if (accountRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(accountRemoveCommand);
        }
    }
}
