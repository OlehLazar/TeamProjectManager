using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IBoardService
{
	Task<IEnumerable<BoardModel>> GetAsync(FilterModel filter);

	Task<BoardModel> GetByIdAsync(int id);

	Task AddAsync(BoardModel boardModel);

	Task<BoardModel> UpdateAsync(BoardModel boardModel);

	Task DeleteAsync(int id);
}
