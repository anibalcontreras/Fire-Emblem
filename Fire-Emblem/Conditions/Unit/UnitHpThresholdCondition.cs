using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class UnitHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public UnitHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int thresholdHp = (int)(activator.BaseHp * _threshold);
        return activator.CurrentHP <= thresholdHp;
    }
}