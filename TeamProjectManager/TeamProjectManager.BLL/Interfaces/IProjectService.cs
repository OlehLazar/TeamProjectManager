using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IProjectService
{
	Task<IEnumerable<ProjectModel>> GetAsync(FilterModel filter);

	Task<ProjectModel> GetByIdAsync(int id);

	Task AddAsync(ProjectModel projectModel);

	Task<ProjectModel> UpdateAsync(ProjectModel projectModel);

	Task DeleteAsync(int id);
}
