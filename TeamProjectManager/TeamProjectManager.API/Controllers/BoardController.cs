using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Board;
using TeamProjectManager.API.DTOs.Task;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Services;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IUserService _userService;
	private readonly IBoardService _boardService;

    public BoardController(IUserService userService, IBoardService boardService)
    {
        _userService = userService;
        _boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBoards()
	{
		var userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
		var boards = await _boardService.GetBoardsByUserIdAsync(userId);

		var boardDtos = boards.Select(b => new BoardDto(b.Id, b.Name, b.Description, b.CreatedDate, b.ProjectId));
		return Ok(boardDtos);
	}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBoardById(int id)
    {
		var board = await _boardService.GetBoardByIdAsync(id);
		if (board == null)
		{
			return NotFound("Board not found");
		}

		var boardDto = new FullBoardDto(
			board.Id,
			board.Name,
			board.Description,
			board.ProjectId,
			board.Tasks.Select(t => new TaskDto(t.Id, t.Name, t.Description, t.StartDate, t.EndDate, board.Id, t.CreatorId, t.AssigneeId, t.Status)).ToList()
		);

		return Ok(boardDto);
	}

    [HttpPost]
    public async Task<IActionResult> CreateBoard(CreateBoardDto createBoardDto)
    {
		var validationResult = await new CreateBoardValidator().ValidateAsync(createBoardDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var boardModel = new BoardModel
		{
			Name = createBoardDto.Name,
			Description = createBoardDto.Description,
			ProjectId = createBoardDto.ProjectId,
		};

		await _boardService.AddBoardAsync(boardModel);
		return Ok();
	}
}
