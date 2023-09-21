using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string Name { get; private set; }
        public string Color { get; private set; }
        public string Icon { get; private set; }
    }
}
