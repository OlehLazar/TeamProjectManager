using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class TeamRepository(ManagerDbContext context) 
	: AbstractRepository(context), ITeamRepository
{
	public async Task<IEnumerable<Team>> GetAllAsync()
	{
		return await _context.Teams.ToListAsync();
	}

	public async Task<IEnumerable<Team>> GetAsync(int skip, int take)
	{
		return await _context.Teams
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<Team> GetByIdAsync(int id)
	{
		return await _context.Teams.FindAsync(id);
	}

	public async Task AddAsync(Team entity)
	{
		_context.Teams.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Team entity)
	{
		_context.Teams.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Team entity)
	{
		_context.Teams.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		await DeleteAsync(await GetByIdAsync(id));
	}
}
