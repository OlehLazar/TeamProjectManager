using System.ComponentModel.DataAnnotations;

namespace TeamProjectManager.DAL.Entities;

public class Project
{
	public int Id { get; set; }

	[Length(5, 50)]
	public string Name { get; set; } = string.Empty;

	[Length(10, 500)]
	public string Description { get; set; } = string.Empty;

	public int TeamId { get; set; }

	public Team Team { get; set; } = default!;

	public ICollection<Board>? Boards { get; init; }
}