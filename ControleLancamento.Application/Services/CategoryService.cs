using AutoMapper;
using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.Categories.Queries;
using MediatR;

namespace ControleLancamento.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var productsQuery = new GetCategoriesQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }
        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetCategoryByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<CategoryDTO>(result);
        }
        public async Task CreateAsync(CategoryDTO productDto)
        {
            var productCreateCommand = _mapper.Map<CategoryCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }
        public async Task UpdateAsync(CategoryDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<CategoryUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new CategoryRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
