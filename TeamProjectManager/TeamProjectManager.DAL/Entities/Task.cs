namespace TeamProjectManager.DAL.Entities;

public class Task
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public int ProjectId { get; set; }
	public int CreatorId { get; set; }
	public int AssigneeId { get; set; }
	public bool Status { get; set; }

	public Project Project { get; set; }
	public User Creator { get; set; }
	public User Assignee { get; set; }
}
