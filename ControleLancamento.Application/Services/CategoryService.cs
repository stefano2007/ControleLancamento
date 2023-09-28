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
            var categorysQuery = new GetCategoriesQuery();

            if (categorysQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categorysQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }
        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryByIdQuery = new GetCategoryByIdQuery(id.Value);

            if (categoryByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryByIdQuery);

            return _mapper.Map<CategoryDTO>(result);
        }
        public async Task<CategoryDTO> CreateAsync(CategoryCreateDTO categoryDto)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
            var result = await _mediator.Send(categoryCreateCommand);

            return _mapper.Map<CategoryDTO>(result);
        }
        public async Task<CategoryDTO> UpdateAsync(CategoryUpdateDTO categoryDto)
        {
            var categoryUpdateCommand = _mapper.Map<AccountUpdateCommand>(categoryDto);
            var result = await _mediator.Send(categoryUpdateCommand);

            return _mapper.Map<CategoryDTO>(result);
        }
        public async Task RemoveAsync(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);
            if (categoryRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(categoryRemoveCommand);
        }
    }
}
