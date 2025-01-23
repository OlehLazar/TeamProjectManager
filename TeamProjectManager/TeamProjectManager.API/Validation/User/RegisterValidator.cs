using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
		RuleFor(user => user.FirstName)
				.NotEmpty().WithMessage("Name cannot be empty.")
				.MinimumLength(2).WithMessage("Name must be at least 2 characters long.");

		RuleFor(user => user.LastName)
			.NotEmpty().WithMessage("Name cannot be empty.")
			.MinimumLength(2).WithMessage("Name must be at least 2 characters long.");

		RuleFor(user => user.Password).PasswordRules();
	}
}
