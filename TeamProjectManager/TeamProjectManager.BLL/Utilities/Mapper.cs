using TeamProjectManager.BLL.Models;
using TeamProjectManager.DAL.Entities;
using Task = TeamProjectManager.DAL.Entities.Task;

namespace TeamProjectManager.BLL.Utilities;

public static class Mapper
{
	public static UserModel MapUserModel(User user)
	{
		ArgumentNullException.ThrowIfNull(user);

		return new UserModel
		{
			Id = user.Id,
			FirstName = user.FirstName,
			LastName = user.LastName,
			UserName = user.UserName!,
			Avatar = user.Avatar,
		};
	}

	public static User MapUser(UserModel userModel)
	{
		ArgumentNullException.ThrowIfNull(userModel);

		return new User
		{
			Id = userModel.Id,
			FirstName = userModel.FirstName,
			LastName = userModel.LastName,
			UserName = userModel.UserName,
			Avatar = userModel.Avatar,
		};
	}

	public static TeamModel MapTeamModel(Team team)
	{
		ArgumentNullException.ThrowIfNull(team);

		return new TeamModel
		{
			Id = team.Id,
			Name = team.Name,
			Description = team.Description,
			LeaderId = team.LeaderId,
			Leader = MapUserModel(team.Leader),
			Members = team.Members?.Select(MapUserModel).ToList() ?? [],
			Projects = team.Projects?.Select(MapProjectModel).ToList() ?? [],
		};
	}

	public static Team MapTeam(TeamModel teamModel)
	{
		ArgumentNullException.ThrowIfNull(teamModel);

		return new Team
		{
			Id = teamModel.Id,
			Name = teamModel.Name,
			Description = teamModel.Description,
			LeaderId = teamModel.LeaderId.ToString(),
			Leader = MapUser(teamModel.Leader),
			Members = teamModel.Members?.Select(MapUser).ToList() ?? [],
			Projects = teamModel.Projects?.Select(MapProject).ToList() ?? [],
		};
	}

	public static TaskModel MapTaskModel(Task task)
	{
		ArgumentNullException.ThrowIfNull(task);

		return new TaskModel
		{
			Id = task.Id,
			Name = task.Name,
			Description = task.Description,
			StartDate = task.StartDate,
			EndDate = task.EndDate,
			BoardId = task.BoardId,
			CreatorId = task.CreatorId,
			AssigneeId = task.AssigneeId,
			Status = task.Status,
			Board = MapBoardModel(task.Board),
			Creator = MapUserModel(task.Creator),
			Assignee = MapUserModel(task.Assignee),
		};
	}

	public static Task MapTask(TaskModel taskModel)
	{
		ArgumentNullException.ThrowIfNull(taskModel);

		return new Task
		{
			Id = taskModel.Id,
			Name = taskModel.Name,
			Description = taskModel.Description,
			StartDate = taskModel.StartDate,
			EndDate = taskModel.EndDate,
			BoardId = taskModel.BoardId,
			CreatorId = taskModel.CreatorId.ToString(),
			AssigneeId = taskModel.AssigneeId.ToString(),
			Status = taskModel.Status,
			Board = MapBoard(taskModel.Board),
			Creator = MapUser(taskModel.Creator),
			Assignee = MapUser(taskModel.Assignee),
		};
	}

	public static ProjectModel MapProjectModel(Project project)
	{
		ArgumentNullException.ThrowIfNull(project);

		return new ProjectModel
		{
			Id = project.Id,
			Name = project.Name,
			Description = project.Description,
			TeamId = project.TeamId,
			Boards = project.Boards?.Select(MapBoardModel).ToList() ?? [],
		};
	}

	public static Project MapProject(ProjectModel projectModel)
	{
		ArgumentNullException.ThrowIfNull(projectModel);

		return new Project
		{
			Id = projectModel.Id,
			Name = projectModel.Name,
			Description = projectModel.Description,
			TeamId = projectModel.TeamId,
			Boards = projectModel.Boards.Select(MapBoard).ToList() ?? [],
		};
	}

	public static NotificationModel MapNotificationModel(Notification notification)
	{
		ArgumentNullException.ThrowIfNull(notification);

		return new NotificationModel
		{
			Id = notification.Id,
			Title = notification.Title,
			Content = notification.Content,
			CreatedAt = notification.CreatedAt,
			IsRead = notification.IsRead,
			UserId = notification.UserId,
			User = MapUserModel(notification.User),
		};
	}

	public static Notification MapNotification(NotificationModel notificationModel)
	{
		ArgumentNullException.ThrowIfNull(notificationModel);

		return new Notification
		{
			Id = notificationModel.Id,
			Title = notificationModel.Title,
			Content = notificationModel.Content,
			CreatedAt = notificationModel.CreatedAt,
			IsRead = notificationModel.IsRead,
			UserId = notificationModel.UserId.ToString(),
			User = MapUser(notificationModel.User),
		};
	}

	public static BoardModel MapBoardModel(Board board)
	{
		ArgumentNullException.ThrowIfNull(board);

		return new BoardModel
		{
			Id = board.Id,
			Name = board.Name,
			Description = board.Description,
			ProjectId = board.ProjectId,
			Project = MapProjectModel(board.Project),
			Tasks = board.Tasks.Select(MapTaskModel).ToList(),
		};
	}

	public static Board MapBoard(BoardModel boardModel)
	{
		ArgumentNullException.ThrowIfNull(boardModel);

		return new Board
		{
			Id = boardModel.Id,
			Name = boardModel.Name,
			Description = boardModel.Description,
			ProjectId = boardModel.ProjectId,
			Project = MapProject(boardModel.Project),
			Tasks = boardModel.Tasks.Select(MapTask).ToList(),
		};
	}
}
