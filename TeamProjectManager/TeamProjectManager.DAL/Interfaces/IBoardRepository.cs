using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface IBoardRepository : IRepository<Board>
{
	Task<IEnumerable<Board>> GetAllByUserIdAsync(int userId);

	Task<IEnumerable<Board>> GetAllByProjectIdAsync(int projectId);
}
