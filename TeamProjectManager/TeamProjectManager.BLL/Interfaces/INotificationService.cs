using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface INotificationService
{
	Task<IEnumerable<NotificationModel>> GetNotificationsAsync(string userId, int page, int pageSize);

	Task NotifyUserAsync(string userId, string title, string content);

	Task ReadNotificationAsync(int id);

	Task DeleteNotificationAsync(int id);
}
