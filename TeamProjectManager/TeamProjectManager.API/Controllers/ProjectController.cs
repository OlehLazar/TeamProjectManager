using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.BLL.Interfaces;
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
			return Ok(projects);
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
