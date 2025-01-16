using System.ComponentModel.DataAnnotations;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation;

public static class UserValidator
{
	public static ValidationResult ValidateUser(LoginDto user)
	{
		if (user == null)
		{
			return new ValidationResult(false, "User cannot be null.");
		}

		var errors = new List<string>();

		var userNameResult = ValidateUserName(user.UserName);
		if (!userNameResult.IsValid)
		{
			errors.Add(userNameResult.Message!);
		}

		var passwordResult = ValidatePassword(user.Password);
		if (!passwordResult.IsValid)
		{
			errors.Add(passwordResult.Message!);
		}

		return errors.Count == 0
			? new ValidationResult(true)
			: new ValidationResult(false, string.Join(" ", errors));
	}

	public static ValidationResult ValidateUser(RegisterDto user)
	{
		if (user == null)
		{
			return new ValidationResult(false, "User cannot be null.");
		}

		var errors = new List<string>();

		var firstNameResult = ValidateName(user.FirstName);
		if (!firstNameResult.IsValid)
		{
			errors.Add(firstNameResult.Message!);
		}

		var lastNameResult = ValidateName(user.LastName);
		if (!lastNameResult.IsValid)
		{
			errors.Add(lastNameResult.Message!);
		}

		var userNameResult = ValidateUserName(user.UserName);
		if (!userNameResult.IsValid)
		{
			errors.Add(userNameResult.Message!);
		}

		var passwordResult = ValidatePassword(user.Password);
		if (!passwordResult.IsValid)
		{
			errors.Add(passwordResult.Message!);
		}

		return errors.Count == 0
			? new ValidationResult(true)
			: new ValidationResult(false, string.Join(" ", errors));
	}

	public static ValidationResult ValidateUser(UpdateUserDto user)
	{
		if (user == null)
		{
			return new ValidationResult(false, "User cannot be null.");
		}

		var errors = new List<string>();

		var firstNameResult = ValidateName(user.FirstName!);
		if (!firstNameResult.IsValid)
		{
			errors.Add(firstNameResult.Message!);
		}

		var lastNameResult = ValidateName(user.LastName!);
		if (!lastNameResult.IsValid)
		{
			errors.Add(lastNameResult.Message!);
		}

		var avatarResult = ValidateAvatar(user.Avatar!);
		if (!avatarResult.IsValid)
		{
			errors.Add(avatarResult.Message!);
		}

		return errors.Count == 0
			? new ValidationResult(true)
			: new ValidationResult(false, string.Join(" ", errors));
	}

	public static ValidationResult ValidateName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return new ValidationResult(false, "Name cannot be empty.");
		}

		if (name.Length < 2)
		{
			return new ValidationResult(false, "Name must be at least 2 characters long.");
		}

		return new ValidationResult(true);
	}

	public static ValidationResult ValidateUserName(string userName)
	{
		if (string.IsNullOrWhiteSpace(userName))
		{
			return new ValidationResult(false, "Username cannot be empty.");
		}

		if (userName.Length < 5)
		{
			return new ValidationResult(false, "Username must be at least 5 characters long.");
		}

		return new ValidationResult(true);
	}

	public static ValidationResult ValidatePassword(string password)
	{
		if (string.IsNullOrWhiteSpace(password))
		{
			return new ValidationResult(false, "Password cannot be empty.");
		}

		if (password.Length < 8)
		{
			return new ValidationResult(false, "Password should be at least 8 characters long.");
		}

		if (!password.Any(char.IsDigit))
		{
			return new ValidationResult(false, "Password should contain at least one digit.");
		}

		if (!password.Any(char.IsUpper))
		{
			return new ValidationResult(false, "Password should contain at least one uppercase letter.");
		}

		if (password.All(char.IsLetterOrDigit))
		{
			return new ValidationResult(false, "Password should contain at least one special symbol.");
		}

		return new ValidationResult(true);
	}

	public static ValidationResult ValidateAvatar(string avatar)
	{
		if (!Uri.TryCreate(avatar, UriKind.Absolute, out _))
		{
			return new ValidationResult(false, "Avatar must be a valid URL.");
		}

		return new ValidationResult(true);
	}
}
