using FluentValidation;

public static class CustomValidators
{
	public static IRuleBuilderOptions<T, string> PasswordRules<T>(this IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder
			.NotEmpty().WithMessage("Password cannot be empty.")
			.MinimumLength(8).WithMessage("Password should be at least 8 characters long.")
			.Matches(@"\d").WithMessage("Password should contain at least one digit.")
			.Matches(@"[A-Z]").WithMessage("Password should contain at least one uppercase letter.")
			.Matches(@"[^a-zA-Z0-9]").WithMessage("Password should contain at least one special symbol.");
	}
}
