using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitBeginAsAttackerCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit unit, Unit opponent)
    {
        return combat.Attacker == unit;
    }
}
