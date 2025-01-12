namespace TeamProjectManager.DAL.Interfaces;

public interface ITaskRepository : IRepository<Entities.Task>
{
	Task<IEnumerable<Entities.Task>> GetAllByBoardIdAsync(int boardId);
}
