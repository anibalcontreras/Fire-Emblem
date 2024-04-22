using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class MultiCondition : ICondition
{
    private readonly List<ICondition> _conditions;

    public MultiCondition(IEnumerable<ICondition> conditions)
    {
        _conditions = new List<ICondition>(conditions);
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return _conditions.All(condition => condition.IsConditionMet(combat, activator, opponent));
    }

    public ICondition Clone()
    {
        return new MultiCondition(_conditions.Select(condition => condition.Clone()));
    }
}