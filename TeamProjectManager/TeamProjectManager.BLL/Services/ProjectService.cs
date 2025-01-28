using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class ProjectService : IProjectService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IProjectRepository _projectRepository;

    public ProjectService(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
		_projectRepository = unitOfWork.ProjectRepository;
	}

	public async Task<IEnumerable<ProjectModel>> GetProjectsByUserIdAsync(int userId)
	{
		var projects = await _projectRepository.GetAllByUserIdAsync(userId);
		AppException.ThrowIfNull(projects, "Ptojects not found");
		return projects.Select(Mapper.MapProjectModel);
	}


	public async Task<IEnumerable<ProjectModel>> GetProjectsByTeamIdAsync(int teamId)
	{
		var projects = await _projectRepository.GetAllByTeamIdAsync(teamId);
		AppException.ThrowIfNull(projects, "Projects not found");
		return projects.Select(Mapper.MapProjectModel);
	}

	public async Task<ProjectModel> GetProjectByIdAsync(int id)
	{
		var project = await _projectRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(project, "Project not found");
		return Mapper.MapProjectModel(project!);
	}

	public async Task AddProjectAsync(ProjectModel projectModel)
	{
		AppException.ThrowIfNull(projectModel, "Project can't be null");
		await _projectRepository.AddAsync(Mapper.MapProject(projectModel));
	}

	public async Task UpdateProjectAsync(ProjectModel projectModel)
	{
		var project = await _projectRepository.GetByIdAsync(projectModel.Id);
		AppException.ThrowIfNull(project, "Project not found");
		await _projectRepository.UpdateAsync(Mapper.MapProject(projectModel));
	}

	public async Task DeleteProjectAsync(int id)
	{
		var project = await _projectRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(project, "Project not found");
		await _projectRepository.DeleteByIdAsync(id);
	}
}
