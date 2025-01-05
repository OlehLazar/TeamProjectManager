namespace TeamProjectManager.BLL.Models;

public class UserModel : AbstractModel
{
    public UserModel(string firstName, string lastName, string userName, string password)
    {
        FirstName = firstName;
		LastName = lastName;
		UserName = userName;
		Password = password;
	}

    public required string FirstName { get; set; }

	public required string LastName { get; set; }

	public required string UserName { get; set; }

	public required string Password { get; set; }

	public string? Avatar { get; set; }
}
