using System.ComponentModel.DataAnnotations;

namespace TeamProjectManager.DAL.Entities;

public class Notification
{
	public int Id { get; set; }

	[Length(5, 50)]
	public string Title { get; set; } = string.Empty;

	[Length(5, 200)]
	public string Content { get; set; } = string.Empty;

	public DateTime CreatedAt { get; set; }

	public bool IsRead { get; set; }

	public int UserId { get; set; }

	public User User { get; set; }
}
