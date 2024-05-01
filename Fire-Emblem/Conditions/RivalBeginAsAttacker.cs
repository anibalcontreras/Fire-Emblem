using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalBeginAsAttacker : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return combat.Attacker == opponent;
    }
}