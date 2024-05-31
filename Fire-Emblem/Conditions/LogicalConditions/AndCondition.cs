using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions.LogicalConditions;

public class AndCondition : ICondition {
    private readonly List<ICondition> _conditions;

    public AndCondition(params ICondition[] conditions) {
        _conditions = new List<ICondition>(conditions);
    }

    public bool IsConditionMet(Unit activator, Unit opponent) {
        return _conditions.All(condition => condition.IsConditionMet(activator, opponent));
    }
}
