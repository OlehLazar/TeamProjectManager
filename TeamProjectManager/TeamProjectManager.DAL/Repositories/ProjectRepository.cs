using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class ProjectRepository(ManagerDbContext context)
	: AbstractRepository(context), IProjectRepository
{
	public async Task<IEnumerable<Project>> GetAllAsync()
	{
		return await _context.Projects.ToListAsync();
	}

	public Task<IEnumerable<Project>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Project> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Project entity)
	{
		throw new NotImplementedException();
	}

	public Task AddAsync(Project entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Project entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

}
