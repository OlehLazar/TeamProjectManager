using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Board;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly ITeamService _teamService;
	private readonly IProjectService _projectService;

	public ProjectController(IUserService userService, ITeamService teamService, IProjectService projectService)
	{
		_userService = userService;
		_teamService = teamService;
		_projectService = projectService;
	}

	[HttpGet]
	public async Task<IActionResult> GetProjects()
	{
		var userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
		var projects = await _projectService.GetProjectsByUserIdAsync(userId);

		var projectDtos = projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.TeamId));
		return Ok(projectDtos);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetProjectById(int id)
	{
		var project = await _projectService.GetProjectByIdAsync(id);
		if (project == null)
		{
			return NotFound("Project not found");
		}

		var projectDto = new FullProjectDto
		(
			project.Id,
			project.Name,
			project.Description,
			project.TeamId,
			project.Boards.Select(b => new BoardDto(b.Id, b.Name, b.Description, b.CreatedDate, b.ProjectId)).ToList()
		);

		return Ok(projectDto);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
	{
		var validationResult = await new CreateProjectValidator().ValidateAsync(createProjectDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var projectModel = new ProjectModel
		{
			Name = createProjectDto.Name,
			Description = createProjectDto.Description,
			TeamId = createProjectDto.TeamId,
			Boards = []
		};

		await _projectService.AddProjectAsync(projectModel);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteProject(int id)
	{
		var project = await _projectService.GetProjectByIdAsync(id);
		if (project == null)
		{
			return NotFound("Project not found.");
		}

		var team = await _teamService.GetTeamByIdAsync(project.TeamId);
		if (team == null)
		{
			return NotFound("Team not found.");
		}

		var userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
		if (team.LeaderId == userId)
		{
			await _projectService.DeleteProjectAsync(id);
			return Ok("Project successfully deleted.");
		}

		return Unauthorized("You are not the leader of this team.");
	}
}
