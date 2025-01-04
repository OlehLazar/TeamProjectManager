using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class UserRepository(ManagerDbContext context)
	: AbstractRepository(context), IUserRepository
{
	public async Task<IEnumerable<User>> GetAllAsync()
	{
		return await _context.Users.ToListAsync();
	}

	public async Task<IEnumerable<User>> GetAsync(int skip, int take)
	{
		return await _context.Users
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<User> GetByIdAsync(int id)
	{
		return await _context.Users.FindAsync(id.ToString());
	}

	public async Task AddAsync(User entity)
	{
		_context.Users.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(User entity)
	{
		_context.Users.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(User entity)
	{
		_context.Users.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		await DeleteAsync(await GetByIdAsync(id));
	}
}
