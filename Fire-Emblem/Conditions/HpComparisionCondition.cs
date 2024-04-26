using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class HpComparisonCondition : ICondition
{
    private readonly int _hpDifference;

    public HpComparisonCondition(int hpDifference)
    {
        _hpDifference = hpDifference;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return activator.CurrentHP >= opponent.CurrentHP + _hpDifference;
    }

    public ICondition Clone()
    {
        return new HpComparisonCondition(_hpDifference);
    }
}