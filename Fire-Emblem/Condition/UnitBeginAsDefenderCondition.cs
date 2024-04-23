using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitBeginAsDefenderCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit unit, Unit opponent)
    {
        return combat.Defender == unit;
    }

    public ICondition Clone()
    {
        return new UnitBeginAsDefenderCondition();
    }
}
