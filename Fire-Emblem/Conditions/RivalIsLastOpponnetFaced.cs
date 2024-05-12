using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalIsLastOpponentFaced : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return  activator.LastUnitFaced == opponent; 
    }
}