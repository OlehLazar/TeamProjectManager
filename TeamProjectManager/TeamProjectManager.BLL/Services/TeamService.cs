using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;
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

	public async Task<IEnumerable<TeamModel>> GetTeamsByUserIdAsync(string userId)
	{
		var teams = await _teamRepository.GetAllByUserIdAsync(userId);
		AppException.ThrowIfNull(teams, "Teams not found");
		return teams.Select(Mapper.MapTeamModel);
	}

	public async Task<TeamModel> GetTeamByIdAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(team, "Team not found");
		var leader = await _unitOfWork.UserRepository.GetByIdAsync(team!.LeaderId);
		team.Leader = leader!;
		return Mapper.MapTeamModel(team!);
	}

	public async Task AddTeamAsync(TeamModel team)
	{
		AppException.ThrowIfNull(team, "Team can't be null");

		var leader = await _unitOfWork.UserRepository.GetByIdAsync(team.LeaderId);

		var teamEntity = new Team
		{
			Name = team.Name,
			Description = team.Description,
			LeaderId = team.LeaderId,
			Leader = leader!,
			Members = [],
			Projects = [],
		};

		await _teamRepository.AddAsync(teamEntity);
	}

	public async Task DeleteTeamAsync(int id)
	{
		var team = await _teamRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(team, "Team not found");
		await _teamRepository.DeleteByIdAsync(id);
	}

	public async Task AddMemeberAsync(int teamId, string userId)
	{
		var team = await _teamRepository.GetByIdAsync(teamId);
		AppException.ThrowIfNull(team, "Team not found");
		var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
		AppException.ThrowIfNull(user, "User not found");
		if (team.Members == null)
		{
			team.Members = [];
		}
		team.Members.Add(user!);
		await _teamRepository.UpdateAsync(team);
	}

	public async Task RemoveMemberAsync(int teamId, string userId)
	{
		var team = await _teamRepository.GetByIdAsync(teamId);
		AppException.ThrowIfNull(team, "Team not found");
		var user = team!.Members!.FirstOrDefault(u => u.Id == userId);
		AppException.ThrowIfNull(user, "User not found");
		team.Members!.Remove(user!);
		await _teamRepository.UpdateAsync(team);
	}
}
