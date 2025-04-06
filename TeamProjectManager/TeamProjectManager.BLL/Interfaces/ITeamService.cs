using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITeamService
{
	Task<IEnumerable<TeamModel>> GetTeamsByUserIdAsync(string userId);

	Task<TeamModel> GetTeamByIdAsync(int id);

	Task AddTeamAsync(TeamModel teamModel);

	Task DeleteTeamAsync(int id);

	Task AddMemeberAsync(int teamId, string userId);

	Task RemoveMemberAsync(int teamId, string userId);
}
