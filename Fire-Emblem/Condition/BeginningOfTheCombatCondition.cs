using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class BeginningOfTheCombatCondition : ICondition
{
    public bool IsConditionMet(Combat combat)
    {
        return combat.State == CombatState.StartOfCombat;
    }
    
    public ICondition Clone()
    {
        return new BeginningOfTheCombatCondition();
    }
}