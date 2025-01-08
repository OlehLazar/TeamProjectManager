using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface INotificationService
{
	Task<IEnumerable<NotificationModel>> GetAsync(FilterModel filter);

	Task<NotificationModel> GetByIdAsync(int id);

	Task AddAsync(NotificationModel notificationModel);

	Task<NotificationModel> UpdateAsync(NotificationModel notificationModel);

	Task DeleteAsync(int id);
}
