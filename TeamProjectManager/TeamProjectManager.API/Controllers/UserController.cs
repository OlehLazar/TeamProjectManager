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

[Authorize]
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
		var user = await _userService.GetUserAsync(User.Identity!.Name!);
		var userDto = new UserDto(user.FirstName, user.LastName, user.UserName, user.Avatar);
		return Ok(userDto);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProfile(UpdateUserDto updateUserDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

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

	[HttpPut("change-password")]
	public async Task<IActionResult> ChangePassword(ChangePasswordDto changeDto)
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

	[HttpDelete]
	public async Task<IActionResult> DeleteProfile()
	{
		var user = await _userService.GetUserAsync(User.Identity!.Name!);
		await _userService.DeleteUserAsync(user.UserName);
		return NoContent();
	}
}
