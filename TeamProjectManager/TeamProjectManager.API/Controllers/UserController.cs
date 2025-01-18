using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Utilities;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	private readonly JwtHelper _jwtHelper;

	public UserController(IUserService userService, JwtHelper jwtHelper)
    {
		_userService = userService;
		_jwtHelper = jwtHelper;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		try
		{
			await _userService.LogoutUserAsync();
			return Ok();
		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpGet("profile")]
	public async Task<IActionResult> GetProfile()
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpPut]
	public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfileDto)
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpPut("change-password")]
	public async Task<IActionResult> ChangePassword(string password)
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpDelete]
	public async Task<IActionResult> DeleteProfile()
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
