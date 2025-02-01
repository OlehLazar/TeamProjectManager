using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Board;
using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.DTOs.Task;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Services;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
	private IUserService _userService;
	private IBoardService _boardService;
	private ITaskService _taskService;

    public TaskController(IUserService userService, IBoardService boardService, ITaskService taskService)
    {
        _userService = userService;
		_boardService = boardService;
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
		try
		{
			int userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
			var tasks = await _taskService.GetTasksByUserIdAsync(userId);

			var taskDtos = tasks.Select(t => new TaskDto(t.Id, t.Name, t.Description,
				t.StartDate, t.EndDate, t.BoardId,
				t.CreatorId, t.AssigneeId, t.Status));

			return Ok(taskDtos);
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
		try
		{
			var task = await _taskService.GetTaskByIdAsync(id);
			if (task == null)
			{
				return NotFound("Task not found");
			}

			var taskDto = new TaskDto(task.Id, task.Name, task.Description, 
				task.StartDate, task.EndDate, task.BoardId, 
				task.CreatorId, task.AssigneeId, task.Status);

			return Ok(taskDto);
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
    public async Task<IActionResult> CreateTask(CreateTaskDto createTaskDto)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> CompleteTask()
    {
        throw new NotImplementedException();
    }
}
