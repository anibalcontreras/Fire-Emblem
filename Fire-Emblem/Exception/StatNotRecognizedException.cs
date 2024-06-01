namespace Fire_Emblem.Exception;

public class StatNotRecognizedException : ApplicationException
{
    private static readonly string DefaultMessage = "Stat not recognized.";
    
    public StatNotRecognizedException() : base(DefaultMessage) {}
}