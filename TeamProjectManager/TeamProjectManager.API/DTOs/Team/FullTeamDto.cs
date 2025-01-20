using TeamProjectManager.API.DTOs.Project;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.DTOs.Team;

public record FullTeamDto(int Id, string Name, string Description, int LeaderId, List<UserDto> Members, List<ProjectDto> Projects);
