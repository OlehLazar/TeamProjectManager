using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Board;
using TeamProjectManager.BLL.Interfaces;
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
		try
        {
			int userId = (await _userService.GetUserAsync(User.Identity!.Name!)).Id;
            var boards = await _boardService.GetBoardsByUserIdAsync(userId);
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
    public async Task<IActionResult> GetBoardById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBoard(CreateBoardDto createBoardDto)
    {
        throw new NotImplementedException();
    }
}
