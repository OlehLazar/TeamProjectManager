using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class BoardRepository(ManagerDbContext context)
	: AbstractRepository(context), IBoardRepository
{
	public async Task<IEnumerable<Board>> GetAllAsync()
	{
		return await _context.Boards.ToListAsync();
	}

	public Task<Board> AddAsync(Board entity)
	{
		throw new NotImplementedException();
	}

	public Task<Board> DeleteAsync(Board entity)
	{
		throw new NotImplementedException();
	}

	public Task<Board> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Board>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Board> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Board> UpdateAsync(Board entity)
	{
		throw new NotImplementedException();
	}
}
