using FluentValidation;
using TeamProjectManager.API.DTOs.Task;

namespace TeamProjectManager.API.Validation;

public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskValidator()
    {
        RuleFor(t => t.Name)
			.MinimumLength(5).WithMessage("Name must be at least 5 characters.")
			.MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

		RuleFor(t => t.Description)
			.MinimumLength(10).WithMessage("Description must be at least 10 characters.")
			.MaximumLength(300).WithMessage("Description can't exceed 300 characters.");

		RuleFor(t => t.EndDate)
			.GreaterThan(t => t.StartDate).WithMessage("EndDate must be greater than StartDate.")
			.InclusiveBetween(DateTime.UtcNow.Date, DateTime.UtcNow.AddYears(1).Date)
			.WithMessage("End date must be within the next year."); ;

		RuleFor(t => t.BoardId)
			.GreaterThan(0).WithMessage("BoardId is required!");

		RuleFor(t => t.AssigneeUsername)
			.NotEmpty().WithMessage("Assignee is required!");
	}
}
