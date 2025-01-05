namespace TeamProjectManager.BLL.Models;

public class NotificationModel : AbstractModel
{
    public NotificationModel(string title, string content, DateTime createdAt, int userId)
    {
        Title = title;
		Content = content;
		CreatedAt = createdAt;
		UserId = userId;
	}

    public required string Title { get; set; }

	public required string Content { get; set; }

	public required DateTime CreatedAt { get; set; }

	public required bool IsRead { get; set; } = default;

	public required int UserId { get; set; }
}
