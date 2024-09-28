using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalHpAboveThresholdCondition : ICondition
{
    private readonly double _threshold;

    public RivalHpAboveThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        double thresholdHp = opponent.BaseHp * _threshold;
        return opponent.CurrentHP >= thresholdHp;
    }
}