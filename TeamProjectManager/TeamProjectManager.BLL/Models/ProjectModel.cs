namespace TeamProjectManager.BLL.Models;

public class ProjectModel : AbstractModel
{
    public ProjectModel(string name, string description, int teamId)
    {
        Name = name;
        Description = description;
        TeamId = teamId;
    }

    public required string Name { get; set; }

	public required string Description { get; set; }

	public required int TeamId { get; set; }
}
