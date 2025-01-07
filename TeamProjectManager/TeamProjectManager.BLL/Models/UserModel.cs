namespace TeamProjectManager.BLL.Models;

public class UserModel : AbstractModel
{
    public UserModel()
    {
        
    }

    public UserModel(string firstName, string lastName, string userName, string password)
    {
        FirstName = firstName;
		LastName = lastName;
		UserName = userName;
		Password = password;
	}

	public string FirstName { get; set; } = default!;

	public string LastName { get; set; } = default!;

	public string UserName { get; set; } = default!;

	public string Password { get; set; } = default!;

	public string? Avatar { get; set; }
}
