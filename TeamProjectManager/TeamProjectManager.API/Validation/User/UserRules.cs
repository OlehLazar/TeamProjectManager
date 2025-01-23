using FluentValidation;

public static class UserRules
{
	public static IRuleBuilderOptions<T, string> NameRules<T>(this IRuleBuilder<T, string> ruleBuilder, string name)
	{
		return ruleBuilder
			.NotEmpty().WithMessage($"{name} cannot be empty.")
			.MinimumLength(2).WithMessage($"{name} must be at least 2 characters long.")
			.MaximumLength(50).WithMessage($"{name} can't be longer than 50 characters.");
	}

	public static IRuleBuilderOptions<T, string> UserNameRules<T>(this IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder
			.NotEmpty().WithMessage("Username cannot be empty.")
			.MinimumLength(5).WithMessage("Username must be at least 5 characters long.")
			.MaximumLength(50).WithMessage("Username can't be longer than 50 characters.");
	}

	public static IRuleBuilderOptions<T, string> PasswordRules<T>(this IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder
			.NotEmpty().WithMessage("Password cannot be empty.")
			.MinimumLength(8).WithMessage("Password should be at least 8 characters long.")
			.Matches(@"\d").WithMessage("Password should contain at least one digit.")
			.Matches(@"[A-Z]").WithMessage("Password should contain at least one uppercase letter.")
			.Matches(@"[^a-zA-Z0-9]").WithMessage("Password should contain at least one special symbol.");
	}

	public static IRuleBuilderOptions<T, string> AvatarRules<T>(this IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder
			.NotEmpty().WithMessage("Avatar URL cannot be empty.")
			.Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Avatar must be a valid URL.");
	}
}
