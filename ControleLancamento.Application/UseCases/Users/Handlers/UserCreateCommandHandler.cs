using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Users.Handlers;
public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
{
    private readonly IUserRepository _userRepository;
    public UserCreateCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(UserCreateCommand request,
        CancellationToken cancellationToken)
    {
        var account = new User(request.Name, request.Email, request.Password, request.Occupation, request.CellPhone);

        if (account == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _userRepository.CreateAsync(account);
        }
    }
}
