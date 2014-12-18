using System;

public static class Validation
{
    public static void CheckForNullOrEmptyString(string value, string argumentName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The argument is Null or Emty!!!", argumentName);
        }
    }
    public static void CheckForNegative(object value, string argumentName)
    {
        if ((decimal)value < 1)
        {
            throw new ArgumentException("The argument must be positive number!!!", argumentName);
        }
    }
    public static void CheckForEmptyString(string value, string argumentName)
    {
        if (value == "")
        {
            throw new ArgumentException("The argument must not be empty string!", argumentName);
        }
    }
}

