using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITaskService
{
	Task<IEnumerable<TaskModel>> GetTasksByUserIdAsync(string userId);

	Task<IEnumerable<TaskModel>> GetTasksByBoardIdAsync(int boardId);

	Task<TaskModel> GetTaskByIdAsync(int id);

	Task CompleteTaskAsync(int id);

	Task AddTaskAsync(TaskModel taskModel);

	Task UpdateTaskAsync(TaskModel taskModel);

	Task DeleteTaskAsync(int id);
}
