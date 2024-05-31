using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class DifferentStatComparision : ICondition
{
    private readonly StatType _firstStatType;
    private readonly StatType _secondStatType;

    public DifferentStatComparision(StatType firstStatType, StatType secondStatType)
    {
        _firstStatType = firstStatType;
        _secondStatType = secondStatType;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetCurrentStat(_firstStatType);
        int opponentStatValue = opponent.GetCurrentStat(_secondStatType);
        return activatorStatValue > opponentStatValue;
    }
}
