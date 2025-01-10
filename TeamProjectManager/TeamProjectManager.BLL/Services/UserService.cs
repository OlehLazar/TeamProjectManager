﻿using Microsoft.AspNetCore.Identity;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.BLL.Validation;
using TeamProjectManager.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.BLL.Services;

public class UserService(UserManager<User> userManager, SignInManager<User> signInManager) 
	: IUserService
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly SignInManager<User> _signInManager = signInManager;

	public async Task<UserModel> GetAsync(string userName)
	{
		AppException.ThrowIfNullOrWhiteSpace(userName, "User name is required.");

		var user = await _userManager.FindByNameAsync(userName);

		if (user == null)
		{
			throw new AppException("User not found.");
		}

		return new UserModel
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			UserName = user.UserName!,
			Avatar = user.Avatar,
		};
	}

	public async Task<IdentityResult> RegisterAsync(UserModel userModel)
	{
		AppException.ThrowIfNull(userModel, "User data is required.");

		var user = new User
		{
			FirstName = userModel.FirstName,
			LastName = userModel.LastName,
			UserName = userModel.UserName,
			Avatar = userModel.Avatar,
		};

		return await _userManager.CreateAsync(user, userModel.Password);
	}

	public async Task<IdentityResult> LoginAsync(string userName, string password)
	{
		AppException.ThrowIfNullOrWhiteSpace(userName, "User name is required.");
		AppException.ThrowIfNullOrWhiteSpace(password, "Password is required.");

		var user = await _userManager.FindByNameAsync(userName);
		if (user == null)
		{
			return IdentityResult.Failed(new IdentityError { Description = "User not found." });
		}

		var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
		if (!result.Succeeded)
		{
			return IdentityResult.Failed(new IdentityError { Description = "Invalid password." });
		}

		return IdentityResult.Success;
	}

	public async Task<UserModel> UpdateAsync(UserModel userModel)
	{
		AppException.ThrowIfNull(userModel, "User data is required.");
		var user = await _userManager.FindByNameAsync(userModel.UserName);
		AppException.ThrowIfNull(user, "User not found.");

		user!.FirstName = userModel.FirstName;
		user.LastName = userModel.LastName;
		user.Avatar = userModel.Avatar;

		await _userManager.UpdateAsync(user);

		return userModel;
	}

	public async Task LogoutAsync()
	{
		await _signInManager.SignOutAsync();
	}

	public async Task<IdentityResult> ChangePasswordAsync(string userName, string password)
	{
		AppException.ThrowIfNullOrWhiteSpace(userName, "User name is required.");
		AppException.ThrowIfNullOrWhiteSpace(password, "Password is required.");

		var user = await _userManager.FindByNameAsync(userName);

		if (user == null)
		{
			return IdentityResult.Failed(new IdentityError { Description = "User not found." });
		}

		var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

		if (!result.Succeeded)
		{
			return IdentityResult.Failed(new IdentityError { Description = "Invalid password." });
		}

		return IdentityResult.Success;
	}

	public async Task DeleteAsync(string userName)
	{
		var user = await _userManager.FindByNameAsync(userName);

		AppException.ThrowIfNull(user, "User not found.");

		var result = await _userManager.DeleteAsync(user!);

		if (!result.Succeeded)
		{
			throw new AppException("Failed to delete the user.");
		}
	}
}