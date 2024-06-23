using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class StatComparisionIncludingBonus : ICondition
{
    
    private readonly StatType _statType;
    
    public StatComparisionIncludingBonus(StatType statType)
    {
        _statType = statType;
    }
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = activator.GetCurrentStat(_statType) + activator.GetBonusStat(_statType);
        int opponentStatValue = opponent.GetCurrentStat(_statType) + opponent.GetBonusStat(_statType);
        return activatorStatValue > opponentStatValue;
    }
}