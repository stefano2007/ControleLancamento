using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AccountTypesController : ControllerBase
{
    private readonly IAccountTypeService _categoryTypeService;
    public AccountTypesController(IAccountTypeService categoryTypeService)
    {
        _categoryTypeService = categoryTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountTypeDTO>>> Get()
    {
        var categories = await _categoryTypeService.GetAccountTypesAsync();
        if (categories == null)
        {
            return NotFound("AccountType not found");
        }
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetAccountType")]
    public async Task<ActionResult<AccountTypeDTO>> Get(int id)
    {
        var category = await _categoryTypeService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("AccountType not found");
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AccountTypeCreateDTO categoryDto)
    {
        if (categoryDto == null)
            return BadRequest("Invalid Data");

        var result = await _categoryTypeService.CreateAsync(categoryDto);

        return new CreatedAtRouteResult("GetAccountType", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] AccountTypeUpdateDTO categoryTypeDto)
    {
        if (id != categoryTypeDto.Id)
            return BadRequest();

        if (categoryTypeDto == null)
            return BadRequest();

        await _categoryTypeService.UpdateAsync(categoryTypeDto);

        return Ok(categoryTypeDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<AccountTypeDTO>> Delete(int id)
    {
        var categoryType = await _categoryTypeService.GetByIdAsync(id);
        if (categoryType == null)
        {
            return NotFound("AccountType not found");
        }

        await _categoryTypeService.RemoveAsync(id);

        return Ok(categoryType);
    }
}

