using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordValidator()
    {
        RuleFor(user => user.OldPassword).PasswordRules();

        RuleFor(user => user.NewPassword).PasswordRules();
	}
}
