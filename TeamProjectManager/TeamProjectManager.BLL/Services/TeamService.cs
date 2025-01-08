using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
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

    public Task<IEnumerable<TeamModel>> GetAsync(FilterModel filter)
	{
		throw new NotImplementedException();
	}

	public Task<TeamModel> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task AddAsync(TeamModel team)
	{
		throw new NotImplementedException();
	}

	public Task<TeamModel> UpdateAsync(TeamModel team)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}
