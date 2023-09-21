using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new
                ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> Handle(CategoryRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _categoryRepository.RemoveAsync(category);
                return result;
            }
        }
    }
}
