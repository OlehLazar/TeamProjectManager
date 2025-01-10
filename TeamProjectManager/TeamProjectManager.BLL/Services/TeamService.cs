using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class TeamService : ITeamService
{
	private IUnitOfWork _unitOfWork;
	private ITeamRepository _teamRepository;

	public TeamService( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
		_teamRepository = unitOfWork.TeamRepository;
	}

    public async Task<IEnumerable<TeamModel>> GetAsync(FilterModel filter)
	{
		throw new NotImplementedException();
	}

	public async Task<TeamModel> GetByIdAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(team, "Team not found");
		return Mapper.MapTeamModel(team!);
	}

	public async Task AddAsync(TeamModel team)
	{
		AppException.ThrowIfNull(team, "Team can't be null");
		var entity = Mapper.MapTeam(team);
		await _teamRepository.AddAsync(entity);
	}

	public async Task UpdateAsync(TeamModel team)
	{
		AppException.ThrowIfNull(team, "Team can't be null");

		var teamEntity = await _teamRepository.GetByIdAsync(team.Id);
		AppException.ThrowIfNull(teamEntity, "Team not found");

		var updatedEntity = Mapper.MapTeam(team);
		await _teamRepository.UpdateAsync(updatedEntity);

		throw new NotImplementedException();
	}

	public async Task DeleteAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);

		AppException.ThrowIfNull(team, "Team not found");

		await _teamRepository.DeleteByIdAsync(id);
	}
}
