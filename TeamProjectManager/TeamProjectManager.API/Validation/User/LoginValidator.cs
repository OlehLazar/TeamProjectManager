using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
		RuleFor(user => user.UserName)
				.NotEmpty().WithMessage("Username cannot be empty.")
				.MinimumLength(5).WithMessage("Username must be at least 5 characters long.");

		RuleFor(user => user.Password)
			.NotEmpty().WithMessage("Password cannot be empty.")
			.MinimumLength(8).WithMessage("Password should be at least 8 characters long.")
			.Matches(@"\d").WithMessage("Password should contain at least one digit.")
			.Matches(@"[A-Z]").WithMessage("Password should contain at least one uppercase letter.")
			.Matches(@"[^a-zA-Z0-9]").WithMessage("Password should contain at least one special symbol.");
	}
}
