using ControleLancamento.Application.UseCases.CategoryTypes.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers
{
    public class GetCategoryTypesQueryHandler : IRequestHandler<GetCategoryTypesQuery, IEnumerable<CategoryType>>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public GetCategoryTypesQueryHandler(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<IEnumerable<CategoryType>> Handle(GetCategoryTypesQuery request,
            CancellationToken cancellationToken)
        {
            return await _categoryTypeRepository.GetCategoryTypesAsync();
        }
    }
}
