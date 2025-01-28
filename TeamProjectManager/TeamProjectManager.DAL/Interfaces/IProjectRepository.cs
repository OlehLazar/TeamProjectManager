using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface IProjectRepository : IRepository<Project>
{
	Task<IEnumerable<Project>> GetAllByUserIdAsync(int userId);

	Task<IEnumerable<Project>> GetAllByTeamIdAsync(int teamId);
}
