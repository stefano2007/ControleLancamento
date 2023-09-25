using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Queries
{
    public class GetCategoryTypeByIdQuery : IRequest<CategoryType>
    {
        public int Id { get; set; }
        public GetCategoryTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
