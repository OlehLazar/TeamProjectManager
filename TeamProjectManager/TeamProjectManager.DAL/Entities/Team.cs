using System.ComponentModel.DataAnnotations;

namespace TeamProjectManager.DAL.Entities;

public class Team
{
	public int Id { get; set; }

	[Length(5, 50)]
	public string Name { get; set; } = string.Empty;

	[Length(5, 200)]
	public string Description { get; set; } = string.Empty;

	public string LeaderId { get; set; }

	public User Leader { get; set; }

	public ICollection<User>? Members { get; init; }

	public ICollection<Project>? Projects { get; init; }
}
