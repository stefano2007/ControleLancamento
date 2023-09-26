using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class CategoryTypesController : ControllerBase
{
    private readonly ICategoryTypeService _categoryTypeService;
    public CategoryTypesController(ICategoryTypeService categoryTypeService)
    {
        _categoryTypeService = categoryTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryTypeDTO>>> Get()
    {
        var categories = await _categoryTypeService.GetCategoryTypesAsync();
        if (categories == null)
        {
            return NotFound("CategoryTypes not found");
        }
        return Ok(categories);
    }

    /// <summary>
    /// Localiza uma tipo categoria específica pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetCategoryType")]
    public async Task<ActionResult<CategoryTypeDTO>> Get(int id)
    {
        var category = await _categoryTypeService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found");
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryTypeCreateDTO categoryDto)
    {
        if (categoryDto == null)
            return BadRequest("Invalid Data");

        var result = await _categoryTypeService.CreateAsync(categoryDto);

        return new CreatedAtRouteResult("GetCategoryType", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryTypeUpdateDTO categoryTypeDto)
    {
        if (id != categoryTypeDto.Id)
            return BadRequest();

        if (categoryTypeDto == null)
            return BadRequest();

        await _categoryTypeService.UpdateAsync(categoryTypeDto);

        return Ok(categoryTypeDto);
    }

    /// <summary>
    /// Deleta uma tipo categoria específica
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryTypeDTO>> Delete(int id)
    {
        var categoryType = await _categoryTypeService.GetByIdAsync(id);
        if (categoryType == null)
        {
            return NotFound("Category not found");
        }

        await _categoryTypeService.RemoveAsync(id);

        return Ok(categoryType);
    }
}

