using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class TeamService : ITeamService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ITeamRepository _teamRepository;

	public TeamService( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
		_teamRepository = unitOfWork.TeamRepository;
	}

    public async Task<IEnumerable<TeamModel>> GetTeamsAsync()
	{
		var teams = await _teamRepository.GetAllAsync();
		AppException.ThrowIfNull(teams, "Teams not found");
		return teams.Select(Mapper.MapTeamModel);
	}

	public async Task<IEnumerable<TeamModel>> GetTeamsByUserIdAsync(int userId)
	{
		var teams = await _teamRepository.GetAllByUserIdAsync(userId.ToString());
		AppException.ThrowIfNull(teams, "Teams not found");
		return teams.Select(Mapper.MapTeamModel);
	}

	public async Task<TeamModel> GetTeamByIdAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(team, "Team not found");
		return Mapper.MapTeamModel(team!);
	}

	public async Task AddTeamAsync(TeamModel team)
	{
		AppException.ThrowIfNull(team, "Team can't be null");
		await _teamRepository.AddAsync(Mapper.MapTeam(team));
	}

	public async Task DeleteTeamAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(team, "Team not found");
		await _teamRepository.DeleteByIdAsync(id);
	}
}
