using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class RivalBeginAsAttacker : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return opponent.IsAttacker;
    }
}