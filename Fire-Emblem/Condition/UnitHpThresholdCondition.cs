using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitHpThresholdCondition : ICondition
{
    private readonly double _threshold;

    public UnitHpThresholdCondition(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Combat combat)
    {
        int thresholdHp = Convert.ToInt32(Math.Floor(combat.Attacker.HP * _threshold));
        bool isHpBelowThreshold = combat.Attacker.CurrentHP <= thresholdHp;
        if (isHpBelowThreshold)
            return true;
        return false;

    }

    public ICondition Clone()
    {
        return new UnitHpThresholdCondition(_threshold);
    }
}