using Fire_Emblem.Stats;

namespace Fire_Emblem.Exception;

public class StatNotRecognizedForRetrieveException : ApplicationException
{
    private static readonly string _defaultMessage = "Stat not recognized for retrieve.";
    private StatType _statType;
    public StatNotRecognizedForRetrieveException(StatType statType) : base(_defaultMessage)
    {
        _statType = statType;
    }
    
}