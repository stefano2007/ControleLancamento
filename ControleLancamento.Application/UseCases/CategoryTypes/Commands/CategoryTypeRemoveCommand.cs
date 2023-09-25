using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Commands
{
    public class CategoryTypeRemoveCommand : IRequest<CategoryType>
    {
        public int Id { get; set; }
        public CategoryTypeRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
