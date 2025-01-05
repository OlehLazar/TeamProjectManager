using Microsoft.AspNetCore.Identity;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IUserService
{
	Task<UserModel> GetAsync(string userName);

	Task<IdentityResult> RegisterAsync(UserModel user);

	Task<IdentityResult> LoginAsync(string userName, string password);

	Task<UserModel> UpdateAsync(UserModel user);

	Task LogoutAsync();

	Task<IdentityResult> ChangePasswordAsync(string userName, string password);

	Task DeleteAsync(string userName);
}
