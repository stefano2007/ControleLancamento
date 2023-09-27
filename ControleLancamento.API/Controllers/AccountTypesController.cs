using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AccountTypesController : ControllerBase
{
    private readonly IAccountTypeService _accountTypeService;
    public AccountTypesController(IAccountTypeService accountTypeService)
    {
        _accountTypeService = accountTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountTypeDTO>>> Get()
    {
        var accountTypes = await _accountTypeService.GetAccountTypesAsync();
        if (accountTypes == null)
        {
            return NotFound("AccountType not found");
        }
        return Ok(accountTypes);
    }

    [HttpGet("{id:int}", Name = "GetAccountType")]
    public async Task<ActionResult<AccountTypeDTO>> Get(int id)
    {
        var category = await _accountTypeService.GetByIdAsync(id);
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

        var result = await _accountTypeService.CreateAsync(categoryDto);

        return new CreatedAtRouteResult("GetAccountType", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] AccountTypeUpdateDTO accountTypeDto)
    {
        if (id != accountTypeDto.Id)
            return BadRequest();

        if (accountTypeDto == null)
            return BadRequest();

        await _accountTypeService.UpdateAsync(accountTypeDto);

        return Ok(accountTypeDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<AccountTypeDTO>> Delete(int id)
    {
        var accountType = await _accountTypeService.GetByIdAsync(id);
        if (accountType == null)
        {
            return NotFound("AccountType not found");
        }

        await _accountTypeService.RemoveAsync(id);

        return Ok(accountType);
    }
}

