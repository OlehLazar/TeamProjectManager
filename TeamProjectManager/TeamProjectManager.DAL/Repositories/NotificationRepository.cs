using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Entities;
using TeamProjectManager.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.DAL.Repositories;

public class NotificationRepository(ManagerDbContext context) 
	: AbstractRepository(context), INotificationRepository
{
	public async Task<IEnumerable<Notification>> GetAllAsync()
	{
		return await _context.Notifications.ToListAsync();
	}

	public async Task<IEnumerable<Notification>> GetAsync(int skip, int take)
	{
		return await _context.Notifications
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<Notification?> GetByIdAsync(int id)
	{
		return await _context.Notifications.FindAsync(id);
	}

	public async Task<IEnumerable<Notification>> GetByUserIdAsync(string userId)
	{
		return await _context.Notifications
			.Where(n => n.UserId == userId)
			.ToListAsync();
	}

	public async Task<int> GetCountAsync(string userId)
	{
		return await _context.Notifications
			.CountAsync(n => n.UserId == userId);
	}

	public async Task AddAsync(Notification entity)
	{
		_context.Notifications.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Notification entity)
	{
		_context.Notifications.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Notification entity)
	{
		_context.Notifications.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var notification = await GetByIdAsync(id);

		if (notification != null)
		{
			await DeleteAsync(notification);
		}
	}
}
