using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class HpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public HpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Unit unit)
    {
        int thresholdHp = Convert.ToInt32(Math.Floor(unit.HP * _threshold));
        return unit.CurrentHP <= thresholdHp;
    }

    public ICondition Clone()
    {
        return new HpThresholdCondition(_threshold);
    }
}