using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class CombatEndedCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        bool firstCondition = activator.CurrentHP <= 0 && activator.HaveAllies == false;
        bool secondCondition = opponent.CurrentHP <= 0 && opponent.HaveAllies == false;
        return firstCondition || secondCondition;
    }
}