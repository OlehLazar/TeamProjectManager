using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class BoardService : IBoardService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IBoardRepository _boardRepository;

    public BoardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
		_boardRepository = _unitOfWork.BoardRepository;
	}

    public async Task<IEnumerable<BoardModel>> GetBoardsByProjectIdAsync(int projectId)
	{
		var boards = await _boardRepository.GetAllByProjectIdAsync(projectId);
		AppException.ThrowIfNull(boards, "Boards not found");
		return boards.Select(Mapper.MapBoardModel);
	}

	public async Task<BoardModel> GeBoardByIdAsync(int id)
	{
		var board = await _boardRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(board, "Board not found");
		return Mapper.MapBoardModel(board!);
	}

	public async Task AddBoardAsync(BoardModel boardModel)
	{
		AppException.ThrowIfNull(boardModel, "Board model is null");
		await _boardRepository.AddAsync(Mapper.MapBoard(boardModel));
	}

	public async Task UpdateBoardAsync(BoardModel boardModel)
	{
		var board = await _boardRepository.GetByIdAsync(boardModel.Id);
		AppException.ThrowIfNull(board, "Board not found");
		await _boardRepository.UpdateAsync(Mapper.MapBoard(boardModel));
	}

	public async Task DeleteBoardAsync(int id)
	{
		var board = await _boardRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(board, "Board not found");
		await _boardRepository.DeleteAsync(board!);
	}
}
