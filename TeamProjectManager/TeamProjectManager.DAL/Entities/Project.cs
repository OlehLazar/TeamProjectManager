namespace TeamProjectManager.DAL.Entities;

public class Project
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string TeamId { get; set; }

	public Team Team { get; set; }

	public ICollection<Task> Tasks { get; set; }
}