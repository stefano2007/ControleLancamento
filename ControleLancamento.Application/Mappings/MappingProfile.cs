using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Application.UseCases.Launchs.Commands;
using ControleLancamento.Application.UseCases.UserAccounts.Commands;
using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<CategoryDTO, CategoryCommand>();
        CreateMap<CategoryCreateDTO, LaunchCreateCommand>();
        CreateMap<CategoryUpdateDTO, CategoryUpdateCommand>();

        CreateMap<CategoryType, CategoryTypeDTO>().ReverseMap();
        CreateMap<CategoryTypeDTO, CategoryTypeCommand>();
        CreateMap<CategoryTypeCreateDTO, CategoryTypeCreateCommand>();
        CreateMap<CategoryTypeUpdateDTO, CategoryTypeUpdateCommand>();

        CreateMap<AccountType, AccountTypeDTO>().ReverseMap();
        CreateMap<AccountTypeDTO, AccountTypeCommand>();
        CreateMap<AccountTypeCreateDTO, AccountTypeCreateCommand>();
        CreateMap<AccountTypeUpdateDTO, AccountTypeUpdateCommand>();

        CreateMap<Account, AccountDTO>().ReverseMap();
        CreateMap<AccountDTO, AccountCommand>();
        CreateMap<AccountCreateDTO, AccountCreateCommand>();
        CreateMap<AccountUpdateDTO, AccountUpdateCommand>();

        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserDTO, UserCommand>();
        CreateMap<UserCreateDTO, UserCreateCommand>();
        CreateMap<UserUpdateDTO, UserUpdateCommand>();

        CreateMap<Launch, LaunchDTO>().ReverseMap();
        CreateMap<LaunchDTO, LaunchCommand>();
        CreateMap<LaunchCreateDTO, LaunchCreateCommand>();
        CreateMap<LaunchUpdateDTO, LaunchUpdateCommand>();

        CreateMap<UserAccount, UserAccountDTO>().ReverseMap();
        CreateMap<UserAccountDTO, UserAccountCommand>();
        CreateMap<UserAccountCreateDTO, UserAccountCreateCommand>();
        CreateMap<UserAccountUpdateDTO, UserAccountUpdateCommand>();
    }
}