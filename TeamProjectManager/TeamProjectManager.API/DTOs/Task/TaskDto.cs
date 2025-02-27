namespace TeamProjectManager.API.DTOs.Task;

public record TaskDto(int Id, string Name, string Description, DateTime StartDate, DateTime EndDate, int BoardId, string CreatorUsername, string AssigneeUsername, bool Status);
