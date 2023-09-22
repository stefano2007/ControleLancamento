﻿using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        if (categories == null)
        {
            return NotFound("Categories not found");
        }
        return Ok(categories);
    }

    /// <summary>
    /// Localiza uma categoria específica pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found");
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto == null)
            return BadRequest("Invalid Data");

        await _categoryService.CreateAsync(categoryDto);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id },
            categoryDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
    {
        if (id != categoryDto.Id)
            return BadRequest();

        if (categoryDto == null)
            return BadRequest();

        await _categoryService.UpdateAsync(categoryDto);

        return Ok(categoryDto);
    }

    /// <summary>
    /// Deleta uma categoria específica
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> Delete(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found");
        }

        await _categoryService.RemoveAsync(id);

        return Ok(category);

    }
}
