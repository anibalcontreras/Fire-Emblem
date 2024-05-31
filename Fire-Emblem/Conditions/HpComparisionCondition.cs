using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class HpComparisonCondition : ICondition
{
    private readonly int _hpDifference;

    public HpComparisonCondition(int hpDifference)
    {
        _hpDifference = hpDifference;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.CurrentHP >= opponent.CurrentHP + _hpDifference;
    }
    
}