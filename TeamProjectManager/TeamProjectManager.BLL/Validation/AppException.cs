﻿namespace TeamProjectManager.BLL.Validation;

public class AppException : Exception
{
    public AppException(string message) 
        : base(message) { }

    public AppException(string message, Exception innerException) 
        : base(message, innerException) { }

    public AppException() { }

	public static void ThrowIfNull(object? obj, string message)
	{
		if (obj == null)
		{
			throw new AppException(message);
		}
	}

	public static void ThrowIfNullOrWhiteSpace(string? str, string message)
	{
		if (string.IsNullOrWhiteSpace(str))
		{
			throw new AppException(message);
		}
	}

	public static void ThrowIfNegative(int number, string message)
	{
		if (number < 0)
		{
			throw new AppException(message);
		}
	}

	public static void ThrowIfNegativeOrZero(int number, string message)
	{
		if (number <= 0)
		{
			throw new AppException(message);
		}
	}

	public static void ThrowIfCondition(bool condition, string message)
	{
		if (condition)
		{
			throw new AppException(message);
		}
	}
}