using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Conditions;

public class NoCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return true;
    }
    
    public ICondition Clone()
    {
        return new NoCondition();
    }
}