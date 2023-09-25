using ControleLancamento.Application.UseCases.CategoryTypes.Queries;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Handlers
{
    public class GetCategoryTypeByIdQueryHandler : IRequestHandler<GetCategoryTypeByIdQuery, CategoryType>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        public GetCategoryTypeByIdQueryHandler(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<CategoryType> Handle(GetCategoryTypeByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _categoryTypeRepository.GetByIdAsync(request.Id);
        }
    }
}
