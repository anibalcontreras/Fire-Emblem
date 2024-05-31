using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class UnitHpGreaterThanCertainPercentage : ICondition
{
    private readonly double _threshold;

    public UnitHpGreaterThanCertainPercentage(double threshold)
    {
        _threshold = threshold;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        double currentHpPercentage = Math.Round((double)activator.CurrentHP / activator.BaseHp, 2);
        return currentHpPercentage >= _threshold;
    }
}