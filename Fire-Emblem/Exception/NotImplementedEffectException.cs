namespace Fire_Emblem.Combats.Exception;

public class NotImplementedEffectException : ApplicationException
{
    private static readonly string DefaultMessage = "Skill effect is not implemented.";

    public NotImplementedEffectException() : base(DefaultMessage) {}
}