using FluentValidation;
using TeamProjectManager.API.DTOs.Board;

namespace TeamProjectManager.API.Validation;

public class CreateBoardValidator : AbstractValidator<CreateBoardDto>
{
    public CreateBoardValidator()
    {
        RuleFor(b => b.Name)
            .MinimumLength(5).WithMessage("Name must be at least 5 characters.")
            .MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(b => b.Description)
            .MinimumLength(10).WithMessage("Description must be at least 10 characters.")
            .MaximumLength(200).WithMessage("Description can't exceed 200 characters.");

        RuleFor(b => b.ProjectId)
            .GreaterThan(0).WithMessage("ProjectId must be greater than 0.");
	}
}
