using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class CategoryTypeRemoveCommandHandler : IRequestHandler<CategoryTypeRemoveCommand, CategoryType>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        public CategoryTypeRemoveCommandHandler(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository ?? throw new
                ArgumentNullException(nameof(categoryTypeRepository));
        }

        public async Task<CategoryType> Handle(CategoryTypeRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryTypeRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _categoryTypeRepository.RemoveAsync(category);
                return result;
            }
        }
    }
}
