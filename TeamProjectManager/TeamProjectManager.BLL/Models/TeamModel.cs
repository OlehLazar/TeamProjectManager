namespace TeamProjectManager.BLL.Models;

public class TeamModel : AbstractModel
{
    public TeamModel(string name, string description, int leaderId)
    {
        Name = name;
		Description = description;
		LeaderId = leaderId;
	}

    public required string Name { get; set; }

	public required string Description { get; set; }

	public int LeaderId { get; set; }
}
