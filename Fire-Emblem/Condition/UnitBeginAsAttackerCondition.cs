using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitBeginAsAttackerCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit unit, Unit opponent)
    {
        return combat.Attacker == unit;
    }

    public ICondition Clone()
    {
        return new UnitBeginAsAttackerCondition();
    }
}
