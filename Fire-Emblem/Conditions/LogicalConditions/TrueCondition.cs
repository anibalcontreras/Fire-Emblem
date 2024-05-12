using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class TrueCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return true;
    }
}