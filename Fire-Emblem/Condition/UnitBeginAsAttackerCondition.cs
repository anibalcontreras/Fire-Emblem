using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitBeginAsAttackerCondition : ICondition
{
    public bool IsConditionMet(Unit unit, Combat combat)
    {
        return unit.IsAttacker;
    }
    
    public ICondition Clone()
    {
        return new UnitBeginAsAttackerCondition();
    }
}