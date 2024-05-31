using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class RivalFirstCombatCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return !opponent.HasBeenAttackerBefore;
    }
}