using FluentValidation;
using TeamProjectManager.API.DTOs.Project;

namespace TeamProjectManager.API.Validation;

public class ProjectValidator : AbstractValidator<CreateProjectDto>
{
    public ProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required!")
            .MinimumLength(5).WithMessage("Name must be at least 5 characters.")
			.MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(p => p.Description)
			.NotEmpty().WithMessage("Description is required!")
			.MinimumLength(10).WithMessage("Description must be at least 10 characters.")
			.MaximumLength(500).WithMessage("Description can't exceed 500 characters.");

		RuleFor(p => p.TeamId)
			.GreaterThan(0).WithMessage("TeamId must be greater than zero!");
	}
}
