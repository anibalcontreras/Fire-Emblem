using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHpStartOfCombatGreaterThanCondition : ICondition
{ 
    private readonly double _threshold;
    
    public UnitHpStartOfCombatGreaterThanCondition(double threshold)
    {
        _threshold = threshold;
    }
    
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        double startOfCombatHpPercentage = Math.Round((double)activator.StartOfCombatHp / activator.BaseHp, 2);
        return startOfCombatHpPercentage >= _threshold;
    }
}