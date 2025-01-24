﻿using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IBoardService
{
	Task<IEnumerable<BoardModel>> GetBoardsByProjectIdAsync(int projectId);

	Task<BoardModel> GeBoardByIdAsync(int id);

	Task AddBoardAsync(BoardModel boardModel);

	Task UpdateBoardAsync(BoardModel boardModel);

	Task DeleteBoardAsync(int id);
}
