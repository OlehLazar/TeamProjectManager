using TeamProjectManager.API.DTOs.Task;

namespace TeamProjectManager.API.DTOs.Board;

public record FullBoardDto(int Id, string Name, string Description, int ProjectId, List<TaskDto> Tasks);
