﻿using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<CategoryDTO, CategoryCommand>();
    }
}