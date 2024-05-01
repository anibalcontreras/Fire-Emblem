using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public UnitHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        int thresholdHp = (int)(activator.BaseHp * _threshold);
        return activator.CurrentHP <= thresholdHp;
    }
}