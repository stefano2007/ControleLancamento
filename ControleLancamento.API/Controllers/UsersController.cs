using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
        var users = await _userService.GetUsersAsync();
        if (users == null)
        {
            return NotFound("User not found");
        }
        return Ok(users);
    }

    [HttpGet("{id:int}", Name = "GetUser")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    [HttpGet("GetByEmail", Name = "GetUserEmail")]
    public async Task<ActionResult<UserDTO>> GetEmail(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserCreateDTO userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid Data");

        var result = await _userService.CreateAsync(userDto);

        return new CreatedAtRouteResult("GetUser", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] UserUpdateDTO userDto)
    {
        if (id != userDto.Id)
            return BadRequest();

        if (userDto == null)
            return BadRequest();

        await _userService.UpdateAsync(userDto);

        return Ok(userDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserDTO>> Delete(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound("User not found");
        }

        await _userService.RemoveAsync(id);

        return Ok(user);
    }
}


