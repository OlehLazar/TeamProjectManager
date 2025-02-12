using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
		RuleFor(user => user.FirstName).NameRules("First name");

		RuleFor(user => user.LastName).NameRules("Last name");

		RuleFor(user => user.Avatar).AvatarRules()
            .When(user => !string.IsNullOrWhiteSpace(user.Avatar));
	}
}
