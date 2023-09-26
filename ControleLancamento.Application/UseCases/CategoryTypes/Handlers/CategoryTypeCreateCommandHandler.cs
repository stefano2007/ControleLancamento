using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Application.UseCases.CategoryTypes.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.CategoryTypes.Handlers;
public class CategoryTypeCreateCommandHandler : IRequestHandler<CategoryTypeCreateCommand, CategoryType>
{
    private readonly ICategoryTypeRepository _categoryTypeRepository;
    public CategoryTypeCreateCommandHandler(ICategoryTypeRepository categoryTypeRepository)
    {
        _categoryTypeRepository = categoryTypeRepository;
    }
    public async Task<CategoryType> Handle(CategoryTypeCreateCommand request,
        CancellationToken cancellationToken)
    {
        var category = new CategoryType(request.Name);

        if (category == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _categoryTypeRepository.CreateAsync(category);
        }
    }
}
