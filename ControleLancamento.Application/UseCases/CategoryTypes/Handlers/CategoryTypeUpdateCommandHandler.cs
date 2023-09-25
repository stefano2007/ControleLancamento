using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class CategoryTypeUpdateCommandHandler : IRequestHandler<CategoryTypeUpdateCommand, CategoryType>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        public CategoryTypeUpdateCommandHandler(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository ??
            throw new ArgumentNullException(nameof(categoryTypeRepository));
        }

        public async Task<CategoryType> Handle(CategoryTypeUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var categoryType = await _categoryTypeRepository.GetByIdAsync(request.Id);

            if (categoryType == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                categoryType.Update(request.Name);

                return await _categoryTypeRepository.UpdateAsync(categoryType);

            }
        }
    }
}
