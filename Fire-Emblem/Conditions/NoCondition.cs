using Fire_Emblem.Teams;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class NoCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return true;
    }
}