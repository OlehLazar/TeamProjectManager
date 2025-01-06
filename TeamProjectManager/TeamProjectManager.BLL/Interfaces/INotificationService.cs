using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface INotificationService
{
	Task<IEnumerable<NotificationModel>> GetAsync(FilterModel filter);

	Task<NotificationModel> GetByIdAsync(int id);

	Task AddAsync(NotificationModel notification);

	Task<NotificationModel> UpdateAsync(NotificationModel notification);

	Task DeleteAsync(int id);
}
