using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
		RuleFor(user => user.FirstName).NameRules("First name");

		RuleFor(user => user.LastName).NameRules("Last name");

		RuleFor(user => user.Password).PasswordRules();
	}
}
