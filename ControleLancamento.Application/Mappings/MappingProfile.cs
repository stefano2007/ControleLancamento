using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.UseCases.AccountTypes.Commands;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Application.UseCases.Users.Commands;
using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<CategoryDTO, CategoryCommand>();
        CreateMap<CategoryCreateDTO, CategoryCreateCommand>();
        CreateMap<CategoryUpdateDTO, CategoryUpdateCommand>();

        CreateMap<CategoryType, CategoryTypeDTO>().ReverseMap();
        CreateMap<CategoryTypeDTO, CategoryTypeCommand>();
        CreateMap<CategoryTypeCreateDTO, CategoryTypeCreateCommand>();
        CreateMap<CategoryTypeUpdateDTO, CategoryTypeUpdateCommand>();

        CreateMap<AccountType, AccountTypeDTO>().ReverseMap();
        CreateMap<AccountTypeDTO, AccountTypeCommand>();
        CreateMap<AccountTypeCreateDTO, AccountTypeCreateCommand>();
        CreateMap<AccountTypeUpdateDTO, AccountTypeUpdateCommand>();

        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserDTO, UserCommand>();
        CreateMap<UserCreateDTO, UserCreateCommand>();
        CreateMap<UserUpdateDTO, UserUpdateCommand>();
    }
}