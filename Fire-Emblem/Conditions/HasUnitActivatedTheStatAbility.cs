using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class HasUnitActivatedTheStatAbility : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return !activator.HasActivatedAlterStatBase;
    }
}
