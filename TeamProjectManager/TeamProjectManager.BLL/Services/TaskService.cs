using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Utilities;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Interfaces;

namespace TeamProjectManager.BLL.Services;

public class TaskService : ITaskService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ITaskRepository _taskRepository;

    public TaskService(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
		_taskRepository = unitOfWork.TaskRepository;
	}

	public async Task<IEnumerable<TaskModel>> GetTasksByUserIdAsync(int userId)
	{
		var tasks = await _taskRepository.GetAllByUserIdAsync(userId.ToString());
		AppException.ThrowIfNull(tasks, "Tasks not found");
		return tasks.Select(Mapper.MapTaskModel);
	}

    public async Task<IEnumerable<TaskModel>> GetTasksByBoardIdAsync(int boardId)
	{
		var tasks = await _taskRepository.GetAllByBoardIdAsync(boardId);
		AppException.ThrowIfNull(tasks, "Tasks not found");
		return tasks.Select(Mapper.MapTaskModel);
	}

	public async Task<TaskModel> GetTaskByIdAsync(int id)
	{
		var task = await _taskRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(task, "Task not found");
		return Mapper.MapTaskModel(task!);
	}

	public async Task CompleteTaskAsync(int id)
	{
		var task = await _taskRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(task, "Task not found");
		task!.Status = true;
		await _taskRepository.UpdateAsync(task);
	}

	public async Task AddTaskAsync(TaskModel taskModel)
	{
		AppException.ThrowIfNull(taskModel, "Task model is null");
		await _taskRepository.AddAsync(Mapper.MapTask(taskModel));
	}

	public async Task UpdateTaskAsync(TaskModel taskModel)
	{
		var task = await _taskRepository.GetByIdAsync(taskModel.Id);
		AppException.ThrowIfNull(task, "Task not found");
		await _taskRepository.UpdateAsync(Mapper.MapTask(taskModel));
	}

	public async Task DeleteTaskAsync(int id)
	{
		var task = await _taskRepository.GetByIdAsync(id);
		AppException.ThrowIfNull(task, "Task not found");
		await _taskRepository.DeleteAsync(task!);
	}
}
