using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class NotificationService : INotificationService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly INotificationRepository _notificationRepository;

    public NotificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
		_notificationRepository = _unitOfWork.NotificationRepository;
	}

    public async Task<IEnumerable<NotificationModel>> GetNotificationsAsync(string userId)
	{
		var notifications = await _notificationRepository.GetByUserIdAsync(userId);
		return notifications.Select(Mapper.MapNotificationModel);
	}

	public async Task<NotificationModel> GetNotificationAsync(int id)
	{
		var notification = await _notificationRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(notification, "Notification not found.");
		return Mapper.MapNotificationModel(notification!);
	}

	public async Task NotifyUserAsync(string userId, string title, string content)
	{
		AppException.ThrowIfNullOrWhiteSpace(title, "Title is required");
		AppException.ThrowIfNullOrWhiteSpace(content, "Content is required");

		var notification = new NotificationModel { Content = content, Title = title, UserId = userId };
		await _notificationRepository.AddAsync(Mapper.MapNotification(notification));
	}

	public async Task ReadNotificationAsync(int id)
	{
		var notification = await _notificationRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(notification, "Notification not found");
		notification!.IsRead = true;
		await _notificationRepository.UpdateAsync(notification);
	}

	public async Task DeleteNotificationAsync(int id)
	{
		var notification = await _notificationRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(notification, "Notification not found");
		await _notificationRepository.DeleteAsync(notification!);
	}
}
