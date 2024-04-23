using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

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