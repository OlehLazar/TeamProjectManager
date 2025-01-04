using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.DAL.Repositories;

public class NotificationRepository(ManagerDbContext context) 
	: AbstractRepository(context), INotificationRepository
{
	public Task<Notification> AddAsync(Notification entity)
	{
		throw new NotImplementedException();
	}

	public Task<Notification> DeleteAsync(Notification entity)
	{
		throw new NotImplementedException();
	}

	public Task<Notification> DeleteByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Notification>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Notification>> GetAsync(int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<Notification> GetByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Notification>> GetByUserIdAsync(string userId, int skip, int take)
	{
		throw new NotImplementedException();
	}

	public Task<int> GetCountAsync(string userId)
	{
		throw new NotImplementedException();
	}

	public Task<Notification> UpdateAsync(Notification entity)
	{
		throw new NotImplementedException();
	}
}
