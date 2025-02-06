namespace TeamProjectManager.BLL.Models;

public class TeamModel : AbstractModel<int>
{
    public TeamModel()
    {
        
    }

    public TeamModel(string name, string description, string leaderId)
    {
        Name = name;
		Description = description;
		LeaderId = leaderId;
	}

    public required string Name { get; set; } = default!;

	public required string Description { get; set; } = default!;

	public string LeaderId { get; set; }

	public UserModel Leader { get; set; }

	public ICollection<UserModel> Members { get; set; }

	public ICollection<ProjectModel> Projects { get; set; }
}
