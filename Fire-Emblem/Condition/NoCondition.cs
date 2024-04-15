using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class NoCondition : ICondition
{
    public bool IsConditionMet(Unit unit)
    {
        return true;
    }
    
    public ICondition Clone()
    {
        return new NoCondition();
    }
}