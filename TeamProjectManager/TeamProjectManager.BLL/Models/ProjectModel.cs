namespace TeamProjectManager.BLL.Models;

public class ProjectModel : AbstractModel<int>
{
    public ProjectModel()
    {
        
    }

    public ProjectModel(string name, string description, int teamId)
    {
        Name = name;
        Description = description;
        TeamId = teamId;
    }

    public required string Name { get; set; } = default!;

	public required string Description { get; set; } = default!;

	public int TeamId { get; set; }

    public TeamModel? Team { get; set; }

    public ICollection<BoardModel> Boards { get; set; } = [];
}
