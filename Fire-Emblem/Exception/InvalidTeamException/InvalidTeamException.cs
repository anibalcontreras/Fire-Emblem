namespace Fire_Emblem.Exception;

public class InvalidTeamException : ApplicationException
{
    protected InvalidTeamException(string message)
        : base(message)
    { }
}