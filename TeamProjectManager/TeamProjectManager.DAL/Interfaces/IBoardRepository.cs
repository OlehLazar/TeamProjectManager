using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface IBoardRepository : IRepository<Board, int>
{
	Task<IEnumerable<Board>> GetAllByUserIdAsync(string userId);

	Task<IEnumerable<Board>> GetAllByProjectIdAsync(int projectId);
}
