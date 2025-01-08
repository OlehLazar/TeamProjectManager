using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface ITaskService
{
	Task<IEnumerable<TaskModel>> GetTasksAsync(FilterModel filter);

	Task<TaskModel> GetTaskByIdAsync(int id);

	Task AddAsync(TaskModel taskModel);

	Task<TaskModel> UpdateAsync(TaskModel taskModel);

	Task DeleteAsync(int id);
}
