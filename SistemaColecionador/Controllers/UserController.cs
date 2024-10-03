using Microsoft.AspNetCore.Mvc;
using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Interfaces.Services;

namespace SistemaColecionador.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] UserLoginDto login)
    {
        if (login == null) return BadRequest();

        var user = _userService.GetUserByCredentials(login);

        if(user == null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post([FromBody] CreateUserDto user)
    {
        if (user == null) return NotFound();

        _userService.CreateUser(user);

        return Ok();
    }
}