using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class LawsOfSacaeCondition : ICondition
{
    private readonly StatType _firstStatType;
    private readonly StatType _secondStatType;

    public LawsOfSacaeCondition(StatType firstStatType, StatType secondStatType)
    {
        _firstStatType = firstStatType;
        _secondStatType = secondStatType;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetCurrentStat(_firstStatType);
        int opponentStatValue = opponent.GetCurrentStat(_secondStatType);
        return activatorStatValue >= opponentStatValue + 5;
    }
}