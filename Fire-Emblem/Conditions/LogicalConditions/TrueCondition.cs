using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions.LogicalConditions;

public class TrueCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return true;
    }
}