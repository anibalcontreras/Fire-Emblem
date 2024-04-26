using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHasNeutralizationBonus : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return true;
    }
    
    public ICondition Clone()
    {
        return new UnitHasNeutralizationBonus();
    }
}