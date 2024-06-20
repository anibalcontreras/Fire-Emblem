using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHpGreaterEqualThanCertainInteger : ICondition
{
    private readonly int _threshold;
    public UnitHpGreaterEqualThanCertainInteger(int threshold)
    {
        _threshold = threshold;
    }
    
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.CurrentHP >= _threshold;
    }
}