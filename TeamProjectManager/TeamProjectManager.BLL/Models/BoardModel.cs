namespace TeamProjectManager.BLL.Models;

public class BoardModel : AbstractModel
{
    public BoardModel(string name, string description, DateTime createdDate, int projectId)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
		ProjectId = projectId;
	}

    public required string Name { get; set; }

	public required string Description { get; set; }

	public DateTime CreatedDate { get; set; }

	public int ProjectId { get; set; }
}
