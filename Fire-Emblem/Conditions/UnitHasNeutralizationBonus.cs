using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHasNeutralizationBonus : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return true;
    }
}