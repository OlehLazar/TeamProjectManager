namespace TeamProjectManager.DAL.Interfaces;

public interface ITaskRepository : IRepository<Entities.Task, int>
{
	Task<IEnumerable<Entities.Task>> GetAllByUserIdAsync(string userId);

	Task<IEnumerable<Entities.Task>> GetAllByBoardIdAsync(int boardId);
}
