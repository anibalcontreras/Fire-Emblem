using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public UnitHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        int thresholdHp = (int)(activator.HP * _threshold);
        return activator.CurrentHP <= thresholdHp;
    }

    public ICondition Clone()
    {
        return new UnitHpThresholdCondition(_threshold);
    }
}