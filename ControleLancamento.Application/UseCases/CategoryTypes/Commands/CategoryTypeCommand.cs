using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Commands
{
    public abstract class CategoryTypeCommand : IRequest<CategoryType>
    {
        public string Name { get; private set; }
    }
}
