namespace TeamProjectManager.BLL.Models;

public class BoardModel : AbstractModel<int>
{
    public BoardModel()
    {
        
    }

    public BoardModel(string name, string description, DateTime createdDate, int projectId)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
		ProjectId = projectId;
	}

    public required string Name { get; set; } = default!;

	public required string Description { get; set; } = default!;

	public DateTime CreatedDate { get; set; }

	public int ProjectId { get; set; }

    public ProjectModel Project { get; set; } = default!;

    public ICollection<TaskModel> Tasks { get; set; } = [];
}
