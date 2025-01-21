namespace TeamProjectManager.API.DTOs.Board;

public record BoardDto(int Id, string Name, string Description, DateTime CreatedDate, int ProjectId);
