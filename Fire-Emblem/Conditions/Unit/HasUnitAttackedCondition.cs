using Fire_Emblem.Effects;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class HasUnitAttackedCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.HasUnitExecutedAStrike;
    }
}