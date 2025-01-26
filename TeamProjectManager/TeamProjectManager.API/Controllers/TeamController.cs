using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.DTOs.Team;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
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
	public async Task<IActionResult> GetTeams()
	{
		try
		{
			int userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
			var teams = await _teamService.GetTeamsByUserIdAsync(userId);

			var teamDtos = teams.Select(t => new TeamDto(t.Id, t.Name, t.Description, t.LeaderId.ToString()));

			return Ok(teamDtos);
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

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTeamById(int id)
	{
		try
		{
			var team = await _teamService.GetTeamByIdAsync(id);
			if (team == null)
			{
				return NotFound("Team not found");
			}

			var teamDto = new FullTeamDto
			(
				team.Id,
				team.Name,
				team.Description,
				team.LeaderId,
				team.Members.Select(m => new UserDto(m.FirstName, m.LastName, m.UserName, m.Avatar)).ToList(),
				team.Projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.TeamId)).ToList()
			);

			return Ok(teamDto);
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

	[HttpPost]
	public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
	{
		try
		{
			var validationResult = await new CreateTeamValidator().ValidateAsync(createTeamDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}

			var teamModel = new TeamModel
			{
				Name = createTeamDto.Name,
				Description = createTeamDto.Description,
				LeaderId = createTeamDto.LeaderId,
				Members = new List<UserModel>(),
				Projects = new List<ProjectModel>()
			};

			await _teamService.AddTeamAsync(teamModel);
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

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateTeam(FullTeamDto updateTeamDto)
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

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTeam(int id)
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
}
