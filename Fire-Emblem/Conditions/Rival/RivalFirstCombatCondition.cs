using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalFirstCombatCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return !opponent.HasBeenAttackerBefore;
    }
}