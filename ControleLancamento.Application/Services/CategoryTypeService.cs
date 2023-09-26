using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Queries;
using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CategoryTypeService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<CategoryTypeDTO>> GetCategoryTypesAsync()
        {
            var categoryTypesQuery = new GetCategoryTypesQuery();

            if (categoryTypesQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryTypesQuery);

            return _mapper.Map<IEnumerable<CategoryTypeDTO>>(result);
        }
        public async Task<CategoryTypeDTO> GetByIdAsync(int? id)
        {
            var categoryTypeByIdQuery = new GetCategoryTypeByIdQuery(id.Value);

            if (categoryTypeByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryTypeByIdQuery);

            return _mapper.Map<CategoryTypeDTO>(result);
        }
        public async Task<CategoryTypeDTO> CreateAsync(CategoryTypeCreateDTO categoryTypeDto)
        {
            var categoryTypeCreateCommand = _mapper.Map<CategoryTypeCreateCommand>(categoryTypeDto);
            var result = await _mediator.Send(categoryTypeCreateCommand);

            return _mapper.Map<CategoryTypeDTO>(result);
        }
        public async Task<CategoryTypeDTO> UpdateAsync(CategoryTypeUpdateDTO categoryTypeDto)
        {
            var categoryTypeUpdateCommand = _mapper.Map<CategoryTypeUpdateCommand>(categoryTypeDto);
            var result = await _mediator.Send(categoryTypeUpdateCommand);

            return _mapper.Map<CategoryTypeDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var categoryTypeRemoveCommand = new CategoryTypeRemoveCommand(id.Value);
            if (categoryTypeRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(categoryTypeRemoveCommand);
        }
    }
}
