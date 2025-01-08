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
			Id = int.Parse(user.Id),
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
			Id = userModel.Id.ToString(),
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
			LeaderId = int.Parse(team.LeaderId),
			Leader = MapUserModel(team.Leader),
			Members = team.Members.Select(MapUserModel).ToList(),
			Projects = team.Projects.Select(MapProjectModel).ToList(),
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
			Members = teamModel.Members.Select(MapUser).ToList(),
			Projects = teamModel.Projects.Select(MapProject).ToList(),
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
			CreatorId = int.Parse(task.CreatorId),
			AssigneeId = int.Parse(task.AssigneeId),
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
			Team = MapTeamModel(project.Team),
			Boards = project.Boards.Select(MapBoardModel).ToList(),
		};
	}

	public static Project MapProject(ProjectModel projectModel)
	{
		ArgumentNullException.ThrowIfNull(projectModel);
	}

	public static NotificationModel MapNotificationModel(Notification notification)
	{
		ArgumentNullException.ThrowIfNull(notification);
	}

	public static Notification MapNotification(NotificationModel notificationModel)
	{
		ArgumentNullException.ThrowIfNull(notificationModel);
	}

	public static BoardModel MapBoardModel(Board board)
	{
		ArgumentNullException.ThrowIfNull(board);
	}

	public static Board MapBoard(BoardModel boardModel)
	{
		ArgumentNullException.ThrowIfNull(boardModel);
	}
}
