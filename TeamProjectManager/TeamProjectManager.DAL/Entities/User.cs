using Microsoft.AspNetCore.Identity;

namespace TeamProjectManager.DAL.Entities;

public class User : IdentityUser
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? Avatar { get; set; }

	public ICollection<Task>? CreatedTasks { get; init; }

	public ICollection<Task>? AssignedTasks { get; init; }

	public ICollection<Team>? Teams { get; init; }
}
