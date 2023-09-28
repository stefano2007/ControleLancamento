using ControleLancamento.Application.UseCases.Categories.Commands;
using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using MediatR;

namespace ControleLancamento.Application.UseCases.Categories.Handlers;
public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryCreateCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Category> Handle(CategoryCreateCommand request,
        CancellationToken cancellationToken)
    {
        var category = new Category(request.CategoryTypeId, request.Name, request.Color, request.Icon);

        if (category == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _categoryRepository.CreateAsync(category);
        }
    }
}
