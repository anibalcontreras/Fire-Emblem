using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class RivalBeginAsAttacker : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return combat.Attacker == opponent;
    }
    
    public ICondition Clone()
    {
        return new RivalBeginAsAttacker();
    }
}