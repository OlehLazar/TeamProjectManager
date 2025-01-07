using Microsoft.AspNetCore.Identity;
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

	public Task<UserModel> GetAsync(string userName)
	{
		throw new NotImplementedException();
	}

	public Task<IdentityResult> RegisterAsync(UserModel user)
	{
		throw new NotImplementedException();
	}

	public Task<IdentityResult> LoginAsync(string userName, string password)
	{
		throw new NotImplementedException();
	}

	public Task<UserModel> UpdateAsync(UserModel user)
	{
		throw new NotImplementedException();
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

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}
