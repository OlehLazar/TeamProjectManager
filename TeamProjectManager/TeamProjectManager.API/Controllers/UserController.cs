using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Utilities;
using TeamProjectManager.BLL.Interfaces;

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
		
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{

	}

	[Authorize]
	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{

	}

	[Authorize]
	[HttpGet("profile")]
	public async Task<IActionResult> GetProfile()
	{

	}

	[Authorize]
	[HttpPut]
	public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfileDto)
	{

	}

	[Authorize]
	[HttpPut("change-password")]
	public async Task<IActionResult> ChangePassword(string password)
	{

	}

	[Authorize]
	[HttpDelete]
	public async Task<IActionResult> DeleteProfile()
	{

	}
}
