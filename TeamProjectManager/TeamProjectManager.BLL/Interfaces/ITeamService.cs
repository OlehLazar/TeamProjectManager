using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITeamService
{
	Task<IEnumerable<TeamModel>> GetAsync(FilterModel filter);

	Task<TeamModel> GetByIdAsync(int id);

	Task AddAsync(TeamModel teamModel);

	Task UpdateAsync(TeamModel teamModel);

	Task DeleteAsync(int id);
}
