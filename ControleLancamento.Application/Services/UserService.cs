using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.Categories.Queries;
using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Application.UseCases.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var usersQuery = new GetUsersQuery();

            if (usersQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(usersQuery);

            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }
        public async Task<UserDTO> GetByIdAsync(int? id)
        {
            var userByIdQuery = new GetUserByIdQuery(id.Value);

            if (userByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(userByIdQuery);

            return _mapper.Map<UserDTO>(result);
        }
        public async Task<UserDTO> CreateAsync(UserCreateDTO userDto)
        {
            var userCreateCommand = _mapper.Map<UserCreateCommand>(userDto);
            var result = await _mediator.Send(userCreateCommand);

            return _mapper.Map<UserDTO>(result);
        }
        public async Task<UserDTO> UpdateAsync(UserUpdateDTO userDto)
        {
            var userUpdateCommand = _mapper.Map<UserUpdateCommand>(userDto);
            var result = await _mediator.Send(userUpdateCommand);

            return _mapper.Map<UserDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var userRemoveCommand = new UserRemoveCommand(id.Value);
            if (userRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(userRemoveCommand);
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var userByIdQuery = new GetUserByEmailQuery(email);

            if (userByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(userByIdQuery);

            return _mapper.Map<UserDTO>(result);
        }
    }
}
