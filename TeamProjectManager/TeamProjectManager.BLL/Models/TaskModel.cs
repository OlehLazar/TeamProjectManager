namespace TeamProjectManager.BLL.Models;

public class TaskModel : AbstractModel
{
    public TaskModel()
    {
        
    }

    public TaskModel(string name, string description, DateTime startDate, DateTime endDate, 
		int boardId, int creatorId, int assigneeId)
    {
        Name = name;
		Description = description;
		StartDate = startDate;
		EndDate = endDate;
		BoardId = boardId;
		CreatorId = creatorId;
		AssigneeId = assigneeId;
	}

    public required string Name { get; set; } = default!;

	public required string Description { get; set; } = default!;

	public DateTime StartDate { get; set; }

	public DateTime EndDate { get; set; }

	public int BoardId { get; set; }

	public int CreatorId { get; set; }

	public int AssigneeId { get; set; }

	public bool Status { get; set; } = default;

	public BoardModel Board { get; set; }

	public UserModel Creator { get; set; }

	public UserModel Assignee { get; set; }
}
