using Microsoft.AspNetCore.Identity;

namespace TeamProjectManager.DAL.Entities;

public class User : IdentityUser
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? Avatar { get; set; }

	public ICollection<Notification>? Notifications { get; set; }

	public ICollection<Task>? CreatedTasks { get; set; }

	public ICollection<Task>? AssignedTasks { get; set; }

	public ICollection<Team>? Teams { get; set; }
}
