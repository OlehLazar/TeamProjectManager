using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class TaskRepository(ManagerDbContext context)
	: AbstractRepository(context), ITaskRepository
{
	public Task<Entities.Task> AddAsync(Entities.Task entity)
	{
		throw new NotImplementedException();
	}

	public Task<Entities.Task> DeleteAsync(Entities.Task entity)
	{
		throw new NotImplementedException();
	}

	public Task<Entities.Task> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Entities.Task>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Entities.Task>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Entities.Task> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Entities.Task> UpdateAsync(Entities.Task entity)
	{
		throw new NotImplementedException();
	}
}
