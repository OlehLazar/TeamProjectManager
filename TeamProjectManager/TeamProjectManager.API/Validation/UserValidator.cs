using System.ComponentModel.DataAnnotations;
using TeamProjectManager.API.DTOs.User;

namespace TeamProjectManager.API.Validation;

public static class UserValidator
{
	public static ValidationResult ValidateUser(LoginDto user)
	{
		throw new NotImplementedException();
	}

	public static ValidationResult ValidateUser(RegisterDto user)
	{
		throw new NotImplementedException();
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
		throw new NotImplementedException();
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
