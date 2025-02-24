using System.ComponentModel.DataAnnotations;

namespace TeamProjectManager.DAL.Entities;

public class Board
{
	public int Id { get; set; }

	[Length(5, 50)]
	public string Name { get; set; } = string.Empty;

	[Length(10, 200)]
	public string Description { get; set; } = string.Empty;

	public DateTime CreatedDate { get; set; }

	public int ProjectId { get; set; }

	public Project? Project { get; set; }

	public ICollection<Task>? Tasks { get; init; }
}
