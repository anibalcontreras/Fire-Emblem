using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class StatComparisionCondition : ICondition
{
    private readonly StatType _statType;

    public StatComparisionCondition(StatType statType)
    {
        _statType = statType;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetCurrentStat(_statType);
        int opponentStatValue = opponent.GetCurrentStat(_statType);
        return activatorStatValue > opponentStatValue;
    }
}
