namespace TeamProjectManager.API.DTOs.User;

public record ChangePasswordDto(string OldPassword, string NewPassword, string ConfirmPassword);
