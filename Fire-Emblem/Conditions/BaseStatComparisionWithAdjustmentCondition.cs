using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class BaseStatComparisionWithAdjustmentCondition : ICondition
{
    private readonly StatType _statType;
    private readonly int _adjustment;

    public BaseStatComparisionWithAdjustmentCondition(StatType statType, int adjustment)
    {
        _statType = statType;
        _adjustment = adjustment;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetBaseStat(_statType);
        int opponentStatValue = opponent.GetBaseStat(_statType) + _adjustment;
        return activatorStatValue >= opponentStatValue;
    }
}