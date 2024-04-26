using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Conditions;

public class BeginningOfTheCombatCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return combat.State == CombatState.StartOfCombat;
    }
    
    public ICondition Clone()
    {
        return new BeginningOfTheCombatCondition();
    }
}