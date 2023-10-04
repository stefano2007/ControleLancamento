using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserAccountsController : ControllerBase
{
    private readonly IUserAccountService _userAccountsService;
    public UserAccountsController(IUserAccountService userAccountService)
    {
        _userAccountsService = userAccountService;
    }
    [HttpGet("", Name = "GetUserAccounts")]
    public async Task<ActionResult<IEnumerable<UserAccountDTO>>> Get(int userId)
    {
        //TODO: preencher userId com informações do Token
        var userAccounts = await _userAccountsService.GetUserAccountsByUserIdQuery(userId);
        if (userAccounts == null)
        {
            return NotFound("UserAccount not found");
        }
        return Ok(userAccounts);
    }

    [HttpGet("{id:int}", Name = "GetUserAccount")]
    public async Task<ActionResult<UserAccountDTO>> Get(int id, int userId)
    {
        //TODO: preencher userId com informações do Token
        var userAccount = await _userAccountsService.GetByIdAndUserIdAsync(id, userId);
        if (userAccount == null)
        {
            return NotFound("UserAccount not found");
        }
        return Ok(userAccount);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserAccountCreateDTO userAccountDto, int userModification)
    {
        //TODO: preencher userModification com informações do Token
        if (userAccountDto == null)
            return BadRequest("Invalid Data");

        var result = await _userAccountsService.CreateAsync(userAccountDto, userModification);

        return new CreatedAtRouteResult("GetUserAccount", new { id = result.Id , userId = result.User?.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] UserAccountUpdateDTO userAccountDto, int userModification)
    {
        //TODO: preencher userModification com informações do Token
        if (id != userAccountDto.Id)
            return BadRequest();

        if (userAccountDto == null)
            return BadRequest();

        await _userAccountsService.UpdateAsync(userAccountDto, userModification);

        return Ok(userAccountDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserAccountDTO>> Delete(int id, int userId)
    {
        //TODO: preencher userId com informações do Token
        var userAccount = await _userAccountsService.GetByIdAndUserIdAsync(id, userId);
        if (userAccount == null)
        {
            return NotFound("UserAccount not found");
        }

        await _userAccountsService.RemoveAsync(id, userId);

        return Ok(userAccount);
    }
}