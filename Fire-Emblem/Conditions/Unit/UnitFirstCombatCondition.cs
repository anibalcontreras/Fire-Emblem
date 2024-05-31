using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class UnitFirstCombatCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return !activator.HasBeenAttackerBefore || !activator.HasBeenDefenderBefore;
    }
}