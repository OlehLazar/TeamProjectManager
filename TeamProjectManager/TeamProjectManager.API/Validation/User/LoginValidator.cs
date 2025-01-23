using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
		RuleFor(user => user.UserName).UserNameRules();

		RuleFor(user => user.Password).PasswordRules();
	}
}
