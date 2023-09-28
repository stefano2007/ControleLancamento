using ControleLancamento.Application.DTOs;
using ControleLancamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleLancamento.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaunchsController : ControllerBase
{
    private readonly ILaunchService _launchService;
    public LaunchsController(ILaunchService launchService)
    {
        _launchService = launchService;
    }

    [HttpGet("GetByAccountId", Name = "GetByAccountId")]
    public async Task<ActionResult<IEnumerable<LaunchDTO>>> GetByAccountId(int accountId)
    {
        var launchs = await _launchService.GetLaunchsByAccountIdAsync(accountId);
        if (launchs == null)
        {
            return NotFound("Launch not found");
        }
        return Ok(launchs);
    }

    [HttpGet("{id:int}", Name = "GetLaunch")]
    public async Task<ActionResult<LaunchDTO>> Get(int id)
    {
        var launch = await _launchService.GetByIdAsync(id);
        if (launch == null)
        {
            return NotFound("Launch not found");
        }
        return Ok(launch);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] LaunchCreateDTO launchDto)
    {
        if (launchDto == null)
            return BadRequest("Invalid Data");

        var result = await _launchService.CreateAsync(launchDto);

        return new CreatedAtRouteResult("GetLaunch", new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] LaunchUpdateDTO launchDto)
    {
        if (id != launchDto.Id)
            return BadRequest();

        if (launchDto == null)
            return BadRequest();

        await _launchService.UpdateAsync(launchDto);

        return Ok(launchDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<LaunchDTO>> Delete(int id)
    {
        var launch = await _launchService.GetByIdAsync(id);
        if (launch == null)
        {
            return NotFound("Launch not found");
        }

        await _launchService.RemoveAsync(id);

        return Ok(launch);
    }

}