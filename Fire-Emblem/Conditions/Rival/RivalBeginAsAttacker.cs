using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalBeginAsAttacker : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return opponent.IsAttacker;
    }
}