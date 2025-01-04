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

	public Task AddAsync(User entity)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteAsync(User entity)
	{
		_context.Users.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public Task DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<User>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<User> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(User entity)
	{
		throw new NotImplementedException();
	}
}
