using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Task;
using TeamProjectManager.BLL.Interfaces;

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
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        throw new NotImplementedException();
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
