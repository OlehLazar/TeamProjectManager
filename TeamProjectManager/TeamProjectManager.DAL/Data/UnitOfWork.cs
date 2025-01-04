using TeamProjectManager.DAL.Interfaces;
using TeamProjectManager.DAL.Repositories;

namespace TeamProjectManager.DAL.Data;

public class UnitOfWork : IUnitOfWork
{
	public UnitOfWork(ManagerDbContext context)
	{
		BoardRepository = new BoardRepository(context);
		NotificationRepository = new NotificationRepository(context);
		ProjectRepository = new ProjectRepository(context);
		TaskRepository = new TaskRepository(context);
		TeamRepository = new TeamRepository(context);
		UserRepository = new UserRepository(context);
	}

	public IBoardRepository BoardRepository { get; }

	public INotificationRepository NotificationRepository { get; }

	public IProjectRepository ProjectRepository { get; }

	public ITaskRepository TaskRepository { get; }

	public ITeamRepository TeamRepository { get; }

	public IUserRepository UserRepository { get; }
}
