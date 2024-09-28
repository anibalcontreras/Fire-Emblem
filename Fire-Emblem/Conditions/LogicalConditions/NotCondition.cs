using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class NotCondition : ICondition
{
    private readonly ICondition _condition;
    
    public NotCondition(ICondition condition)
    {
        _condition = condition;
    }
    
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return !_condition.IsConditionMet(activator, opponent);
    }
}