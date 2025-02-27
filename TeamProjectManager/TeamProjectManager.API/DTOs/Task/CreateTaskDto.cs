﻿namespace TeamProjectManager.API.DTOs.Task;

public record CreateTaskDto(string Name, string Description, DateTime StartDate, DateTime EndDate, int BoardId, string CreatorUsername, string AssigneeUsername);
