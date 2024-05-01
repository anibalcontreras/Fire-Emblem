using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class OrCondition : ICondition
{
    private readonly ICondition _firstCondition;
    private readonly ICondition _secondCondition;
    
    public OrCondition(ICondition firstCondition, ICondition secondCondition)
    {
        _firstCondition = firstCondition;
        _secondCondition = secondCondition;
    }
    
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return _firstCondition.IsConditionMet(combat, activator, opponent) 
               || _secondCondition.IsConditionMet(combat, activator, opponent);
    }
}