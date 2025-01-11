using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITeamService
{
	Task<IEnumerable<TeamModel>> GetTeamsAsync();

	Task<TeamModel> GetTeamByIdAsync(int id);

	Task AddTeamAsync(TeamModel teamModel);

	Task DeleteTeamAsync(int id);
}
