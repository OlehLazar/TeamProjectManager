namespace TeamProjectManager.BLL.Models;

public class TeamModel : AbstractModel
{
    public TeamModel()
    {
        
    }

    public TeamModel(string name, string description, int leaderId)
    {
        Name = name;
		Description = description;
		LeaderId = leaderId;
	}

    public required string Name { get; set; }

	public required string Description { get; set; }

	public int LeaderId { get; set; }

	public UserModel Leader { get; set; }

	public ICollection<UserModel> Members { get; set; }

	public ICollection<ProjectModel> Projects { get; set; }
}
