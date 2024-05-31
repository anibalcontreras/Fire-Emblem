using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class RivalHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public RivalHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int thresholdHp = (int)(opponent.BaseHp * _threshold);
        return opponent.CurrentHP == thresholdHp;
    }
}