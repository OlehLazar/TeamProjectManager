using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class ProjectRepository(ManagerDbContext context)
	: AbstractRepository(context), IProjectRepository
{
	public Task<Project> AddAsync(Project entity)
	{
		throw new NotImplementedException();
	}

	public Task<Project> DeleteAsync(Project entity)
	{
		throw new NotImplementedException();
	}

	public Task<Project> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Project>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Project>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Project> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Project> UpdateAsync(Project entity)
	{
		throw new NotImplementedException();
	}
}
