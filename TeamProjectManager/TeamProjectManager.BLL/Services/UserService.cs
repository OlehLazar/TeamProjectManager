using Microsoft.AspNetCore.Identity;
using TeamProjectManager.BLL.Interfaces;
using TeamProjectManager.BLL.Models;
using TeamProjectManager.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace TeamProjectManager.BLL.Services;

public class UserService : IUserService
{
	private readonly UserManager<User> _userManager;

	private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
		_userManager = userManager;
		_signInManager = signInManager;
	}

    public Task<IdentityResult> ChangePasswordAsync(string userName, string password)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<UserModel> GetAsync(string userName)
	{
		throw new NotImplementedException();
	}

	public Task<IdentityResult> LoginAsync(string userName, string password)
	{
		throw new NotImplementedException();
	}

	public Task LogoutAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IdentityResult> RegisterAsync(UserModel user)
	{
		throw new NotImplementedException();
	}

	public Task<UserModel> UpdateAsync(UserModel user)
	{
		throw new NotImplementedException();
	}
}
