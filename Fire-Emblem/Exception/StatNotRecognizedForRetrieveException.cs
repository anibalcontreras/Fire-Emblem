using Fire_Emblem.Stats;

namespace Fire_Emblem.Exception;

public class StatNotRecognizedForRetrieveException : ApplicationException
{
    private static readonly string DefaultMessage = "Stat not recognized for retrieve.";
    private StatType _statType;
    public StatNotRecognizedForRetrieveException(StatType statType) : base(DefaultMessage)
    {
        _statType = statType;
    }
    
}