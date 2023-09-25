using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Queries;
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
            var productsQuery = new GetCategoryTypesQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<CategoryTypeDTO>>(result);
        }
        public async Task<CategoryTypeDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetCategoryTypeByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<CategoryTypeDTO>(result);
        }
        public async Task CreateAsync(CategoryTypeDTO productDto)
        {
            var productCreateCommand = _mapper.Map<CategoryTypeCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }
        public async Task UpdateAsync(CategoryTypeDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<CategoryTypeUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new CategoryTypeRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
