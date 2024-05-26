using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitBeginAsAttackerCondition : ICondition
{
    public bool IsConditionMet(Unit unit, Unit opponent)
    {
        return unit.IsAttacker;
    }
}
