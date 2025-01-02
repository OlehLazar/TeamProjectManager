using Microsoft.AspNetCore.Identity;

namespace TeamProjectManager.DAL.Entities;

public class User : IdentityUser
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public IEnumerable<Task> CreatedTasks { get; set; }

	public IEnumerable<Task> AssignedTasks { get; set; }

	public IEnumerable<Team> Teams { get; set; }
}
