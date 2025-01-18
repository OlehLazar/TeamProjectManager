using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Utilities;
using TeamProjectManager.API.Validation;
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
			var validationResult = UserValidator.ValidateUser(loginDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Message);
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
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
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
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
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
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
		}
	}

	[Authorize]
	[HttpGet("profile")]
	public async Task<IActionResult> GetProfile()
	{
		try
		{
			var user = await _userService.GetUserAsync(User.Identity!.Name!);
			var userDto = new UserDto(user.FirstName, user.LastName, user.UserName, user.Avatar);
			return Ok(userDto);
		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
		}
	}

	[Authorize]
	[HttpPut]
	public async Task<IActionResult> UpdateProfile(UpdateUserDto updateUserDto)
	{
		try
		{

		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
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
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
		}
	}

	[Authorize]
	[HttpDelete]
	public async Task<IActionResult> DeleteProfile()
	{
		try
		{
			var user = await _userService.GetUserAsync(User.Identity!.Name!);
			await _userService.DeleteUserAsync(user.UserName);
			return NoContent();
		}
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
		}
	}
}
