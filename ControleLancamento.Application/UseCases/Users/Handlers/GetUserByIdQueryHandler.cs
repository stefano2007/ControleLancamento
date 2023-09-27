﻿using ControleLancamento.Application.UseCases.Users.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.Id);
        }
    }
}
