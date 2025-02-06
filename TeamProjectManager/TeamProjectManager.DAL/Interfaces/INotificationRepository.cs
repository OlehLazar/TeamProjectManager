using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface INotificationRepository : IRepository<Notification, int>
{
	Task<IEnumerable<Notification>> GetByUserIdAsync(string userId, int skip, int take);

	Task<int> GetCountAsync(string userId);
}