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
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
    {
		_userService = userService;
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
	public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto updateUserDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		try
		{
			var userName = User.Identity!.Name!;
			var user = new UserModel
			{
				FirstName = updateUserDto.FirstName!,
				LastName = updateUserDto.LastName!,
				UserName = userName,
				Avatar = updateUserDto.Avatar,
			};

			await _userService.UpdateUserAsync(user);
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
	[HttpPut("change-password")]
	public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changeDto)
	{
		try
		{
			var validationResult = await new ChangePasswordValidator().ValidateAsync(changeDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}

			var user = await _userService.GetUserAsync(User.Identity!.Name!);
			var result = await _userService.ChangePasswordAsync(user.UserName, changeDto.NewPassword);
			if (result.Succeeded)
			{
				return NoContent();
			}

			return BadRequest(result.Errors);
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
