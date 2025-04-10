﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.DTOs.Team;
using TeamProjectManager.API.DTOs.User;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly ITeamService _teamService;
	private readonly IProjectService _projectService;

	public TeamController(IUserService userService, ITeamService teamService, IProjectService projectService)
	{
		_userService = userService;
		_teamService = teamService;
		_projectService = projectService;
	}

	[HttpGet]
	public async Task<IActionResult> GetTeams()
	{
		var userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
		var teams = await _teamService.GetTeamsByUserIdAsync(userId);
		var teamDtos = teams.Select(t => new TeamDto(t.Id, t.Name, t.Description, t.LeaderId));
		return Ok(teamDtos);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTeamById(int id)
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
			team.Leader.UserName,
			team.Members.Select(m => new UserDto(m.FirstName, m.LastName, m.UserName, m.Avatar)).ToList(),
			team.Projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.TeamId)).ToList()
		);

		return Ok(teamDto);
	}

	[HttpPost]
	public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
	{
		var validationResult = await new CreateTeamValidator().ValidateAsync(createTeamDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var leader = await _userService.GetUserAsync(User.Identity!.Name!);
		var teamModel = new TeamModel
		{
			Name = createTeamDto.Name,
			Description = createTeamDto.Description,
			LeaderId = leader.Id,
			Members = [],
			Projects = []
		};

		await _teamService.AddTeamAsync(teamModel);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTeam(int id)
	{
		var team = await _teamService.GetTeamByIdAsync(id);
		if (team == null)
		{
			return NotFound("Team not found");
		}

		var user = await _userService.GetUserAsync(User.Identity!.Name!);
		if (team.LeaderId == user.Id)
		{
			await _teamService.DeleteTeamAsync(id);
			return Ok(new { message = "Team successfully deleted" });
		}

		return Unauthorized("You are not the leader of this team");
	}

	[HttpPost("{teamId}/leave")]
	public async Task<IActionResult> LeaveTeam(int teamId)
	{
		var team = await _teamService.GetTeamByIdAsync(teamId);
		if (team == null)
		{
			return NotFound("Team not found");
		}

		var user = await _userService.GetUserAsync(User.Identity!.Name!);
		if (team.LeaderId == user.Id)
		{
			return BadRequest("Leader can't leave the team");
		}

		await _teamService.RemoveMemberAsync(teamId, user.Id);
		return Ok(new { message = "You have left the team" });
	}

	[HttpPost("{id}/add-member")]
	public async Task<IActionResult> AddMember(int id, [FromBody] string userName)
	{
		var team = await _teamService.GetTeamByIdAsync(id);
		if (team == null)
		{
			return NotFound("Team not found");
		}

		var user = await _userService.GetUserAsync(userName);
		if (user == null)
		{
			return NotFound("User not found");
		}

		var currentUser = await _userService.GetUserAsync(User.Identity!.Name!);
		if (team.LeaderId != currentUser.Id)
		{
			return Unauthorized("Only the team leader can add members");
		}

		await _teamService.AddMemeberAsync(id, user.Id);
		return Ok(new { message = "Member successfully added" });
	}

	[HttpGet("{boardId}/members")]
	public async Task<IActionResult> GetMembers(int boardId)
	{
		var teamId = (await _projectService.GetProjectByBoardIdAsync(boardId)).TeamId;
		var team = await _teamService.GetTeamByIdAsync(teamId);
		var teamMembers = team.Members.ToList();
		teamMembers.Add(team.Leader);
		return Ok(teamMembers);
	}
}
