using TeamProjectManager.API.DTOs.Board;

namespace TeamProjectManager.API.DTOs.Project;

public record FullProjectDto(int Id, string Name, string Description, int TeamId, List<BoardDto> Boards);
