﻿using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;
using TeamProjectManager.DAL.Repositories;

namespace TeamProjectManager.BLL.Services;

public class ProjectService : IProjectService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IProjectRepository _projectRepository;
	private readonly ITeamRepository _teamRepository;

	public ProjectService(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
		_projectRepository = unitOfWork.ProjectRepository;
		_teamRepository = unitOfWork.TeamRepository;
	}

	public async Task<IEnumerable<ProjectModel>> GetProjectsByUserIdAsync(string userId)
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

	public async Task<ProjectModel> GetProjectByBoardIdAsync(int boardId)
	{
		var projects = await _unitOfWork.ProjectRepository.GetAllAsync();
		var project = projects.FirstOrDefault(p => p.Boards!.Any(b => b.Id == boardId));
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

	public async Task DeleteProjectAsync(int id, string userId)
	{
		var project = await _projectRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(project, "Project not found");

		var team = await _teamRepository.GetByIdAsync(project!.TeamId);
		AppException.ThrowIfNull(team, "Team not found");

		if (team!.LeaderId != userId)
		{
			throw new UnauthorizedAccessException("You are not the leader of this team.");
		}

		await _projectRepository.DeleteByIdAsync(id);
	}
}
