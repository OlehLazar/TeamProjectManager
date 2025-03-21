﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProjectManager.API.DTOs.Notification;
using TeamProjectManager.API.Validation;
using TeamProjectManager.BLL.Interfaces;

namespace TeamProjectManager.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IUserService _userService;
	private readonly INotificationService _notificationService;

    public NotificationController(IUserService userService, INotificationService notificationService)
    {
        _userService = userService;
        _notificationService = notificationService;
    }

    [HttpPost("notify")]
    public async Task<IActionResult> NotifyUser(CreateNotificationDto createNotificationDto)
    {
		var validationResult = new CreateNotificationValidator().Validate(createNotificationDto);
		if (!validationResult.IsValid)
		{
			return BadRequest(validationResult.Errors);
		}

		var userId = (await _userService.GetUserAsync(createNotificationDto.UserName)).Id;
		await _notificationService.NotifyUserAsync(userId, createNotificationDto.Title, createNotificationDto.Content);

		return NoContent();
	}
}
