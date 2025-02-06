using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IProjectService
{
	Task<IEnumerable<ProjectModel>> GetProjectsByUserIdAsync(string userId);	

	Task<IEnumerable<ProjectModel>> GetProjectsByTeamIdAsync(int teamId);

	Task<ProjectModel> GetProjectByIdAsync(int id);

	Task AddProjectAsync(ProjectModel projectModel);

	Task UpdateProjectAsync(ProjectModel projectModel);

	Task DeleteProjectAsync(int id);
}
