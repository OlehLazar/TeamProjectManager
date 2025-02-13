using TeamProjectManager.API.DTOs.Team;
using FluentValidation;

namespace TeamProjectManager.API.Validation;

public class CreateTeamValidator : AbstractValidator<CreateTeamDto>
{
    public CreateTeamValidator()
    {
        RuleFor(t => t.Name)
            .MinimumLength(5).WithMessage("Name must be at least 5 characters.")
			.MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(t => t.Description)
            .MinimumLength(5).WithMessage("Description must be at least 5 characters.")
			.MaximumLength(200).WithMessage("Description can't exceed 200 characters.");

        RuleFor(t => t.LeaderUsername)
            .UserNameRules();
	}
}
