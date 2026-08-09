using System;

public class InvalidResultOperationException : Exception
{
    private const string message = "The provided status code is a success status code. Use Success instead of Failure.";
    public InvalidResultOperationException() : base(message)
    {

    }
}