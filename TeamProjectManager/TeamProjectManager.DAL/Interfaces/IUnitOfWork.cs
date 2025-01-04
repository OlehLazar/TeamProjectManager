namespace TeamProjectManager.DAL.Interfaces;

public interface IUnitOfWork
{
	IBoardRepository BoardRepository { get; }

	INotificationRepository NotificationRepository { get; }

	IProjectRepository ProjectRepository { get; }

	ITaskRepository TaskRepository { get; }

	ITeamRepository TeamRepository { get; }

	IUserRepository UserRepository { get; }
}
