using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Queries
{
    public class GetCategoryTypesQuery : IRequest<IEnumerable<CategoryType>>
    {
    }
}
