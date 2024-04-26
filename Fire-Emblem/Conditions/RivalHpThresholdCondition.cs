using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public RivalHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        int thresholdHp = (int)(opponent.BaseHp * _threshold);
        return opponent.CurrentHP <= thresholdHp;
    }

    public ICondition Clone()
    {
        return new UnitHpThresholdCondition(_threshold);
    }
}