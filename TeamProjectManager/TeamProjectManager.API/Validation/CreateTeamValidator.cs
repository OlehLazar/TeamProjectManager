using TeamProjectManager.API.DTOs.Team;
using FluentValidation;

namespace TeamProjectManager.API.Validation;

public class CreateTeamValidator : AbstractValidator<CreateTeamDto>
{
    public CreateTeamValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Name is required!")
            .MinimumLength(5).WithMessage("Name must be at least 5 characters.")
			.MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(t => t.Description)
			.NotEmpty().WithMessage("Description is required!")
            .MinimumLength(5).WithMessage("Description must be at least 5 characters.")
			.MaximumLength(200).WithMessage("Description can't exceed 200 characters.");

        RuleFor(t => t.LeaderId)
			.GreaterThan(0).WithMessage("LeaderId must be greater than 0.");
	}
}
