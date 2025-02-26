namespace TeamProjectManager.BLL.Models;

public class TaskModel : AbstractModel<int>
{
    public TaskModel()
    {
        
    }

    public TaskModel(string name, string description, DateTime startDate, DateTime endDate, 
		int boardId, string creatorId, string assigneeId)
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

	public string CreatorId { get; set; }

	public string AssigneeId { get; set; }

	public bool Status { get; set; } = default;

	public UserModel Creator { get; set; }

	public UserModel Assignee { get; set; }
}
