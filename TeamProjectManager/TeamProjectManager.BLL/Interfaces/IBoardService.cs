using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IBoardService
{
	Task<IEnumerable<BoardModel>> GetAsync(FilterModel filter);

	Task<BoardModel> GetByIdAsync(int id);

	Task AddAsync(BoardModel board);

	Task<BoardModel> UpdateAsync(BoardModel board);

	Task DeleteAsync(int id);
}
