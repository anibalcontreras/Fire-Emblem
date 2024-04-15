using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitInitiatesCombatCondition : ICondition
{
    public bool IsConditionMet(Unit unit)
    {
        return unit.IsAttacker;
    }
    
    public ICondition Clone()
    {
        return new UnitInitiatesCombatCondition();
    }
}