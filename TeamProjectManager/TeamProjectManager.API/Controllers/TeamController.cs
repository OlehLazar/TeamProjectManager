using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Team;
using TeamProjectManager.BLL.Interfaces;

namespace TeamProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TeamController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly ITeamService _teamService;

	public TeamController(IUserService userService, ITeamService teamService)
	{
		_userService = userService;
		_teamService = teamService;
	}

	[HttpGet]
	public async Task<IActionResult> GetTeams(int userId)
	{
		throw new NotImplementedException();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTeamById(int id)
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
	{
		throw new NotImplementedException();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateTeam(FullTeamDto updateTeamDto)
	{
		throw new NotImplementedException();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTeam(int id)
	{
		throw new NotImplementedException();
	}
}
