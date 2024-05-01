using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class NotCondition : ICondition
{
    private readonly ICondition _condition;
    
    public NotCondition(ICondition condition)
    {
        _condition = condition;
    }
    
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return !_condition.IsConditionMet(combat, activator, opponent);
    }
}