using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Board;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IProjectService _projectService;

	public ProjectController(IUserService userService, IProjectService projectService)
	{
		_userService = userService;
		_projectService = projectService;
	}

	[HttpGet]
	public async Task<IActionResult> GetProjects()
	{
		try
		{
			int userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
			var projects = await _projectService.GetProjectsByUserIdAsync(userId);

			var projectDtos = projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.TeamId));
			return Ok(projectDtos);
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
	public async Task<IActionResult> GetProjectById(int id)
	{
		try
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
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occured.", error = ex.Message });
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
	{
		try
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
		catch (AppException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { message = "An unexpected error occured.", error = ex.Message });
		}
	}
}
