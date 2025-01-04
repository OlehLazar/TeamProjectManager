using System.ComponentModel.DataAnnotations;

namespace TeamProjectManager.DAL.Entities;

public class Task
{
	public int Id { get; set; }

	[Length(5, 50)]
	public string Name { get; set; } = string.Empty;

	[Length(10, 300)]
	public string Description { get; set; } = string.Empty;

	public DateTime StartDate { get; set; }

	public DateTime EndDate { get; set; }

	public int BoardId { get; set; }

	public string CreatorId { get; set; }

	public string AssigneeId { get; set; }

	public bool Status { get; set; }

	public Board Board { get; set; }

	public User Creator { get; set; }

	public User Assignee { get; set; }
}
