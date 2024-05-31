namespace Fire_Emblem.Exception;

public class NotImplementedEffectException : ApplicationException
{
    private static readonly string DefaultMessage = "Skill effect is not implemented.";

    public NotImplementedEffectException() : base(DefaultMessage) {}
}