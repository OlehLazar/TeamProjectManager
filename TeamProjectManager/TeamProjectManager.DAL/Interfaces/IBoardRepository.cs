using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface IBoardRepository : IRepository<Board>
{
	Task<IEnumerable<Board>> GetAllByProjectIdAsync(int projectId);
}
