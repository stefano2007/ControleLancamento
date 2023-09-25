using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> Handle(CategoryUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                category.Update(request.Name, request.Color, request.Icon);

                return await _categoryRepository.UpdateAsync(category);

            }
        }
    }
}
