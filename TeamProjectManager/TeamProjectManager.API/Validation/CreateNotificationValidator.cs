using FluentValidation;
using TeamProjectManager.API.DTOs.Notification;

namespace TeamProjectManager.API.Validation;

public class CreateNotificationValidator : AbstractValidator<CreateNotificationDto>
{
    public CreateNotificationValidator()
    {
        RuleFor(n => n.Title)
			.MinimumLength(5).WithMessage("Title must be at least 5 characters.")
			.MaximumLength(50).WithMessage("Title can't exceed 50 characters.");

		RuleFor(b => b.Content)
			.MinimumLength(5).WithMessage("Content must be at least 5 characters.")
			.MaximumLength(200).WithMessage("Content can't exceed 200 characters.");
	}
}
