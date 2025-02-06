using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class BoardRepository(ManagerDbContext context)
	: AbstractRepository(context), IBoardRepository
{
	public async Task<IEnumerable<Board>> GetAllAsync()
	{
		return await _context.Boards.ToListAsync();
	}

	public async Task<IEnumerable<Board>> GetAllByUserIdAsync(string userId)
	{
		return await _context.Boards
			.Include(b => b.Project)
				.ThenInclude(p => p.Team)
			.Where(b =>
				b.Project.Team.LeaderId == userId.ToString() ||
				b.Project.Team.Members!.Any(m => m.Id == userId)
			)
			.ToListAsync();
	}

	public async Task<IEnumerable<Board>> GetAllByProjectIdAsync(int projectId)
	{
		return await _context.Boards
			.Where(b => b.ProjectId == projectId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Board>> GetAsync(int skip, int take)
	{
		return await _context.Boards
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<Board?> GetByIdAsync(int id)
	{
		return await _context.Boards.FindAsync(id);
	}

	public async Task AddAsync(Board entity)
	{
		_context.Boards.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Board entity)
	{
		_context.Boards.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Board entity)
	{
		_context.Boards.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var board = await GetByIdAsync(id);

		if (board != null)
		{
			await DeleteAsync(board);
		}
	}
}
