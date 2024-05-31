using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class MultiCondition : ICondition
{
    private readonly List<ICondition> _conditions;

    public MultiCondition(IEnumerable<ICondition> conditions)
    {
        _conditions = new List<ICondition>(conditions);
    }
    
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        foreach (ICondition condition in _conditions)
        {
            if (!condition.IsConditionMet(activator, opponent))
                return false;
        }
        return true;
    }
}