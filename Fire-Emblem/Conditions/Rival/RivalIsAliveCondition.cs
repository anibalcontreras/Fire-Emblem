using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalIsAliveCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return opponent.CurrentHP > 0;
    }
}