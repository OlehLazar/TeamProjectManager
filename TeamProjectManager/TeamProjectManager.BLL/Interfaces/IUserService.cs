using Microsoft.AspNetCore.Identity;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Interfaces;

public interface IUserService
{
	Task<UserModel> GetUserAsync(string userName);

	Task<IdentityResult> RegisterUserAsync(UserModel userModel);

	Task<IdentityResult> LoginUserAsync(string userName, string password);

	Task LogoutUserAsync();

	Task<UserModel> UpdateUserAsync(UserModel userModel);

	Task<IdentityResult> ChangePasswordAsync(string userName, string password);

	Task DeleteUserAsync(string userName);
}
