using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class ProjectRepository(ManagerDbContext context)
	: AbstractRepository(context), IProjectRepository
{
	public async Task<IEnumerable<Project>> GetAllByUserIdAsync(string userId)
	{
		return await _context.Projects.Where(p =>
			p.Team.LeaderId == userId.ToString() ||
			p.Team.Members!.Any(m => m.Id == userId)
		).ToListAsync();
	}

	public async Task<IEnumerable<Project>> GetAllAsync()
	{
		return await _context.Projects.ToListAsync();
	}

	public async Task<IEnumerable<Project>> GetAllByTeamIdAsync(int teamId)
	{
		return await _context.Projects
			.Where(p => p.TeamId == teamId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Project>> GetAsync(int skip, int take)
	{
		return await _context.Projects
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<Project?> GetByIdAsync(int id)
	{
		return await _context.Projects
			.Include(p => p.Boards)
			.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task UpdateAsync(Project entity)
	{
		_context.Projects.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task AddAsync(Project entity)
	{
		_context.Projects.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Project entity)
	{
		_context.Projects.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var project = await GetByIdAsync(id);

		if (project != null)
		{
			await DeleteAsync(project);
		}
	}
}
