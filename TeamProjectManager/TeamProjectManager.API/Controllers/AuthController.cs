using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Utilities;
using TeamProjectManager.API.Validation;
using TeamProjectManager.API.Validation.User;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly JwtHelper _jwtHelper;

    public AuthController(IUserService userService, JwtHelper jwtHelper)
    {
		_userService = userService;
		_jwtHelper = jwtHelper;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		var validationResult = await new LoginValidator().ValidateAsync(loginDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var result = await _userService.LoginUserAsync(loginDto.UserName, loginDto.Password);
		if (result.Succeeded)
		{
			var user = await _userService.GetUserAsync(loginDto.UserName);
			var token = _jwtHelper.GenerateToken(user.Id.ToString(), user.UserName);
			return Ok(new { token });
		}
		else
		{
			return BadRequest(result.Errors);
		}
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{
		var validationResult = await new RegisterValidator().ValidateAsync(registerDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var userModel = new UserModel(registerDto.FirstName, registerDto.LastName, registerDto.UserName, registerDto.Password);
		var result = await _userService.RegisterUserAsync(userModel);
		if (result.Succeeded)
		{
			return Ok();
		}
		else
		{
			return BadRequest(result.Errors);
		}
	}

	[Authorize]
	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await _userService.LogoutUserAsync();
		return Ok();
	}
}
