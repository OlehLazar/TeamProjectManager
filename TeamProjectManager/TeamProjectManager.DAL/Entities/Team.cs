namespace TeamProjectManager.DAL.Entities;

public class Team
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string LeaderId { get; set; }

	public User Leader { get; set; }

	public ICollection<User> Members { get; set; }

	public ICollection<Project> Projects { get; set; }
}
