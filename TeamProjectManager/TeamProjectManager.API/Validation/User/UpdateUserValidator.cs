using FluentValidation;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.FirstName).NameRules("First name")
            .When(user => !string.IsNullOrWhiteSpace(user.FirstName));

        RuleFor(user => user.LastName).NameRules("Last name")
			.When(user => !string.IsNullOrWhiteSpace(user.LastName));

		RuleFor(user => user.Avatar).AvatarRules()
            .When(user => !string.IsNullOrWhiteSpace(user.Avatar));
	}
}
