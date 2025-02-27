using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Task;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly ITaskService _taskService;

    public TaskController(IUserService userService, ITaskService taskService)
    {
        _userService = userService;
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
		var userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
		var tasks = await _taskService.GetTasksByUserIdAsync(userId);

		var taskDtos = tasks.Select(t => new TaskDto(
			t.Id, 
			t.Name, 
			t.Description,
			t.StartDate, 
			t.EndDate, 
			t.BoardId,
			t.Creator.UserName, 
			t.Assignee.UserName, 
			t.Status
		));

		return Ok(taskDtos);
	}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
		var task = await _taskService.GetTaskByIdAsync(id);
		if (task == null)
		{
			return NotFound("Task not found");
		}

		var taskDto = new TaskDto(
			task.Id, 
			task.Name, 
			task.Description,
			task.StartDate, 
			task.EndDate, 
			task.BoardId,
			task.Creator.UserName, 
			task.Assignee.UserName, 
			task.Status
		);

		return Ok(taskDto);
	}

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskDto createTaskDto)
    {
		var validationResult = await new CreateTaskValidator().ValidateAsync(createTaskDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var taskModel = new TaskModel
		{
			Name = createTaskDto.Name,
			Description = createTaskDto.Description,
			StartDate = createTaskDto.StartDate,
			EndDate = createTaskDto.EndDate,
			BoardId = createTaskDto.BoardId,
			CreatorId = (await _userService.GetUserAsync(createTaskDto.CreatorUsername)).Id,
			AssigneeId = (await _userService.GetUserAsync(createTaskDto.AssigneeUsername)).Id,
		};

		await _taskService.AddTaskAsync(taskModel);
		return Ok();
	}

    [HttpPut]
    public async Task<IActionResult> CompleteTask(int taskId)
    {
		var task = await _taskService.GetTaskByIdAsync(taskId);
		if (task == null)
		{
			return NotFound("Task not found");
		}

		var user = await _userService.GetUserAsync(User.Identity!.Name!);
		if (user.Id != task.AssigneeId)
		{
			return BadRequest("This task wasn't assigned to you");
		}

		await _taskService.CompleteTaskAsync(taskId);
		return Ok();
	}
}
