namespace TeamProjectManager.BLL.Models;

public class NotificationModel : AbstractModel<int>
{
    public NotificationModel()
    {
        
    }

    public NotificationModel(string title, string content, DateTime createdAt, string userId)
    {
        Title = title;
		Content = content;
		CreatedAt = createdAt;
		UserId = userId;
	}

    public required string Title { get; set; } = default!;

	public required string Content { get; set; } = default!;

	public DateTime CreatedAt { get; set; }

	public bool IsRead { get; set; } = default;

	public required string UserId { get; set; }
}
