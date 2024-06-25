using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class StatComparisionWithAdjustmentCondition : ICondition
{
    private readonly StatType _statType;
    private readonly int _adjustment;

    public StatComparisionWithAdjustmentCondition(StatType statType, int adjustment)
    {
        _statType = statType;
        _adjustment = adjustment;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetCurrentStat(_statType);
        int opponentStatValue = opponent.GetCurrentStat(_statType) + _adjustment;
        return activatorStatValue >= opponentStatValue;
    }
}