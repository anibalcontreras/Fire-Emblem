using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class IsUnitAliveCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.CurrentHP > 0;
    }
}