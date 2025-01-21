namespace TeamProjectManager.API.DTOs.Notification;

public record NotificationDto(int Id, string Title, string Content, DateTime CreatedAt, bool IsRead, int UserId);
