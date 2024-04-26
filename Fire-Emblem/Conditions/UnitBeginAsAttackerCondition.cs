using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Conditions;

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
