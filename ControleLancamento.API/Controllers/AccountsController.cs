using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;


[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDTO>>> Get()
    {
        var categories = await _accountService.GetAccountsAsync();
        if (categories == null)
        {
            return NotFound("Accounts not found");
        }
        return Ok(categories);
    }

    /// <summary>
    /// Localiza uma categoria específica pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetAccount")]
    public async Task<ActionResult<AccountDTO>> Get(int id)
    {
        var account = await _accountService.GetByIdAsync(id);
        if (account == null)
        {
            return NotFound("Account not found");
        }
        return Ok(account);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AccountCreateDTO accountDto)
    {
        if (accountDto == null)
            return BadRequest("Invalid Data");

        var result = await _accountService.CreateAsync(accountDto);

        return new CreatedAtRouteResult("GetAccount", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] AccountUpdateDTO accountDto)
    {
        if (id != accountDto.Id)
            return BadRequest();

        if (accountDto == null)
            return BadRequest();

        var result = await _accountService.UpdateAsync(accountDto);

        return Ok(result);
    }

    /// <summary>
    /// Deleta uma categoria específica
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<AccountDTO>> Delete(int id)
    {
        var account = await _accountService.GetByIdAsync(id);
        if (account == null)
        {
            return NotFound("Account not found");
        }

        await _accountService.RemoveAsync(id);

        return Ok(account);

    }
}

