using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class TaskRepository(ManagerDbContext context)
	: AbstractRepository(context), ITaskRepository
{
	public async Task<IEnumerable<Entities.Task>> GetAllAsync()
	{
		return await _context.Tasks.ToListAsync();
	}

	public async Task<IEnumerable<Entities.Task>> GetAsync(int skip, int take)
	{
		return await _context.Tasks
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<Entities.Task?> GetByIdAsync(int id)
	{
		return await _context.Tasks.FindAsync(id);
	}

	public async Task AddAsync(Entities.Task entity)
	{
		_context.Tasks.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Entities.Task entity)
	{
		_context.Tasks.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Entities.Task entity)
	{
		_context.Tasks.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var task = await GetByIdAsync(id);

		if (task != null)
		{
			await DeleteAsync(task);
		}
	}
}
