using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITaskService
{
	Task<IEnumerable<TaskModel>> GetTasksAsync(FilterModel filter);

	Task<TaskModel> GetTaskByIdAsync(int id);

	Task AddAsync(TaskModel task);

	Task<TaskModel> UpdateAsync(TaskModel task);

	Task DeleteAsync(int id);
}
