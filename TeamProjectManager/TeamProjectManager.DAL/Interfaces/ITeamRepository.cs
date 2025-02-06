using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface ITeamRepository : IRepository<Team, int>
{
	Task<IEnumerable<Team>> GetAllByUserIdAsync(string userId);
}
