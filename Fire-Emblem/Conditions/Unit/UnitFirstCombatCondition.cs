using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitFirstCombatCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return !activator.HasBeenAttackerBefore || !activator.HasBeenDefenderBefore;
    }
}