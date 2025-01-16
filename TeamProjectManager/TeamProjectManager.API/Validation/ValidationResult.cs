namespace TeamProjectManager.API.Validation;

public class ValidationResult
{
	public bool IsValid { get; set; }
	public string? Message { get; set; }

	public ValidationResult(bool isValid, string message)
	{
		IsValid = isValid;
		Message = message;
	}

    public ValidationResult(bool isValid)
    {
		IsValid = isValid;   
    }
}
