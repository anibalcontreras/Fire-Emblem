namespace Fire_Emblem.Exception;

public class NotImplementedEffectException : ApplicationException
{
    private static readonly string _defaultMessage = "Skill effect is not implemented.";

    public NotImplementedEffectException() : base(_defaultMessage) {}
}