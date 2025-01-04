using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class UserRepository(ManagerDbContext context)
	: AbstractRepository(context), IUserRepository
{
	public Task<User> AddAsync(User entity)
	{
		throw new NotImplementedException();
	}

	public Task<User> DeleteAsync(User entity)
	{
		throw new NotImplementedException();
	}

	public Task<User> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<User>> GetAllAsync()
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

	public Task<User> UpdateAsync(User entity)
	{
		throw new NotImplementedException();
	}
}
