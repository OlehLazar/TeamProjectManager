using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface IProjectRepository : IRepository<Project, int>
{
	Task<IEnumerable<Project>> GetAllByUserIdAsync(string userId);

	Task<IEnumerable<Project>> GetAllByTeamIdAsync(int teamId);
}
