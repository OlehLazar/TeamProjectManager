using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class TeamRepository(ManagerDbContext context) 
	: AbstractRepository(context), ITeamRepository
{
	public Task<Team> AddAsync(Team entity)
	{
		throw new NotImplementedException();
	}

	public Task<Team> DeleteAsync(Team entity)
	{
		throw new NotImplementedException();
	}

	public Task<Team> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Team>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Team>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Team> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Team> UpdateAsync(Team entity)
	{
		throw new NotImplementedException();
	}
}
