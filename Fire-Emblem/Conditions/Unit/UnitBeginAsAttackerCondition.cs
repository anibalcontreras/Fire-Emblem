using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class UnitBeginAsAttackerCondition : ICondition
{
    public bool IsConditionMet(Unit unit, Unit opponent)
    {
        return unit.IsAttacker;
    }
}
