using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Application.UseCases.AccountTypes.Queries;
using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AccountTypeService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<AccountTypeDTO>> GetAccountTypesAsync()
        {
            var accountTypesQuery = new GetAccountTypesQuery();

            if (accountTypesQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(accountTypesQuery);

            return _mapper.Map<IEnumerable<AccountTypeDTO>>(result);
        }
        public async Task<AccountTypeDTO> GetByIdAsync(int? id)
        {
            var accountTypeByIdQuery = new GetAccountTypeByIdQuery(id.Value);

            if (accountTypeByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(accountTypeByIdQuery);

            return _mapper.Map<AccountTypeDTO>(result);
        }
        public async Task<AccountTypeDTO> CreateAsync(AccountTypeCreateDTO accountTypeDto)
        {
            var accountTypeCreateCommand = _mapper.Map<AccountTypeCreateCommand>(accountTypeDto);
            var result = await _mediator.Send(accountTypeCreateCommand);

            return _mapper.Map<AccountTypeDTO>(result);
        }
        public async Task<AccountTypeDTO> UpdateAsync(AccountTypeUpdateDTO accountTypeDto)
        {
            var accountTypeUpdateCommand = _mapper.Map<AccountTypeUpdateCommand>(accountTypeDto);
            var result = await _mediator.Send(accountTypeUpdateCommand);

            return _mapper.Map<AccountTypeDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var accountTypeRemoveCommand = new AccountTypeRemoveCommand(id.Value);
            if (accountTypeRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(accountTypeRemoveCommand);
        }
    }
}
