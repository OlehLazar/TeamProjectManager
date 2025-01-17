using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.BLL.Interfaces;

namespace TeamProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
		_userService = userService;
		_configuration = configuration;
    }

	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		
	}

	public async Task<IActionResult> Register(RegisterDto registerDto)
	{

	}

	public async Task<IActionResult> Logout()
	{

	}

	public async Task<IActionResult> GetProfile()
	{

	}

	public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfileDto)
	{

	}

	public async Task<IActionResult> ChangePassword(string password)
	{

	}
}
