﻿using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
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
    }
}